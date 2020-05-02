using Clockwerkz.Application;
using Clockwerkz.Application.Jobs.Models;
using Quartz;
using Quartz.Impl.Matchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clockwerkz.Infrastructure
{
    public class JobManager : IJobManager
    {
        private readonly IScheduler _scheduler;

        public JobManager(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        public async Task ScheduleCustomJobAsync(string jobName, string groupName, bool startImmediately, string cronExpression, IDictionary<string, object> jobDataMap)
        {
            var normalizedJobData = NormalizeKeys(jobDataMap);

            var job = JobBuilder
                .Create<IJob>()
                .WithIdentity(jobName, groupName)
                .UsingJobData(normalizedJobData)
                .StoreDurably(true)
                .Build();

            var triggerName = Guid.NewGuid().ToString();

            var trigger = TriggerBuilder
                .Create()
                .WithIdentity(triggerName, groupName);

            if (cronExpression != null)
            {
                trigger.WithCronSchedule(cronExpression, x => x.InTimeZone(TimeZoneInfo.Utc));

                if (startImmediately)
                {
                    trigger = trigger.StartNow();
                }
            }

            await _scheduler.ScheduleJob(job, trigger.Build());
        }

        public async Task<JobDetailDto> GetJobDetailAsync(string jobGroup, string jobName)
        {
            if (string.IsNullOrEmpty(jobGroup) || string.IsNullOrEmpty(jobName))
            {
                return null;
            }

            var key = JobKey.Create(jobName, jobGroup);
            var jobDetail = await _scheduler.GetJobDetail(key);
            if (jobDetail == null)
            {
                return null;
            }

            var jobDetailDto = new JobDetailDto
            {
                JobName = jobDetail.Key.Name,
                JobGroup = jobDetail.Key.Group,
                JobDataMap = new Dictionary<string, string>()
            };

            if (jobDetail.JobDataMap != null)
            {
                foreach (var jobData in jobDetail.JobDataMap)
                {
                    jobDetailDto.JobDataMap.Add(jobData.Key, jobData.Value.ToString());
                }
            }

            var jobTriggers = await _scheduler.GetTriggersOfJob(key);
            if (jobTriggers != null && jobTriggers.Any())
            {
                jobDetailDto.Triggers = jobTriggers.Select(x => new TriggerDto
                {
                    StartTime = x.StartTimeUtc.Ticks,
                    EndTime = x.EndTimeUtc?.Ticks
                });
            }

            return jobDetailDto;
        }

        private JobDataMap NormalizeKeys(IDictionary<string, object> jobDataMap)
        {
            var upperKeyedDict = jobDataMap.ToDictionary(k => k.Key.ToUpper(), v => v.Value.ToString());
            return new JobDataMap(upperKeyedDict);
        }

        public async Task DeleteJobAsync(string name, string groupName)
        {
            await _scheduler.DeleteJob(JobKey.Create(name, groupName));
        }

        public async Task DeleteTriggerAsync(string name, string groupName)
        {
            await _scheduler.UnscheduleJob(new TriggerKey(name, groupName));
        }

        public async Task Start()
        {
            await _scheduler.Start();
        }

        public async Task<IEnumerable<JobListDto>> GetJobsAsync()
        {
            var jobList = new List<JobListDto>();

            var jobKeys = await _scheduler.GetJobKeys(GroupMatcher<JobKey>.AnyGroup());
            foreach (var jobKey in jobKeys)
            {
                var job = await GetJobAsync(jobKey.Group, jobKey.Name);
                jobList.Add(job);
            }

            return jobList;
        }

        public async Task<JobListDto> GetJobAsync(string jobGroup, string jobName)
        {
            var job = await _scheduler.GetJobDetail(JobKey.Create(jobName, jobGroup));
            if (job == null)
            {
                return null;
            }

            return new JobListDto
            {
                JobGroup = job.Key.Group,
                Name = job.Key.Name,
                Description = job.Description
            };
        }
    }
}
