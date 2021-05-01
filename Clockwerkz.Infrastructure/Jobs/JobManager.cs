using Clockwerkz.Application;
using Clockwerkz.Application.Jobs.Models;
using Clockwerkz.Application.Triggers.Models;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clockwerkz.Infrastructure.Jobs
{
    public class JobManager : IJobManager
    {
        private readonly IScheduler _scheduler;

        public JobManager(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        public async Task<JobListDto> ScheduleJobAsync(
            string jobName,
            string groupName,
            string description,
            bool startImmediately,
            string cronExpression,
            IDictionary<string, object> jobDataMap)
        {
            var normalizedJobData = CreateJobDataMap(jobDataMap);

            var jobDetail = JobBuilder
                .Create<IJob>()
                .WithIdentity(jobName, groupName)
                .UsingJobData(normalizedJobData)
                .WithDescription(description)
                .StoreDurably(true)
                .Build();

            var triggerName = Guid.NewGuid().ToString();

            var trigger = CreateTrigger(triggerName, groupName, null, startImmediately, cronExpression);

            await _scheduler.ScheduleJob(jobDetail, trigger);

            return new JobListDto
            {
                JobName = jobDetail.Key.Name,
                JobGroup = jobDetail.Key.Group,
                Description = jobDetail.Description,
                SchedulerName = _scheduler.SchedulerName
            };
        }

        public async Task<bool> PauseJobAsync(string jobName, string groupName)
        {
            await _scheduler.PauseJob(JobKey.Create(jobName, groupName));
            return true;
        }

        public async Task<bool> DeleteJobAsync(string jobName, string groupName)
        {
            var result = await _scheduler.DeleteJob(JobKey.Create(jobName, groupName));
            return result;
        }

        public async Task<IEnumerable<TriggerDto>> GetTriggersAsync(string jobName, string groupName)
        {
            var triggers = await _scheduler.GetTriggersOfJob(JobKey.Create(jobName, groupName));

            var result = triggers.Select(async trigger =>
            {
                var state = await _scheduler.GetTriggerState(trigger.Key);

                return new TriggerDto
                {
                    Name = trigger.Key.Name,
                    Group = trigger.Key.Group,
                    StartTime = trigger.StartTimeUtc,
                    EndTime = trigger.EndTimeUtc,
                    PreviousFireTime = trigger.GetPreviousFireTimeUtc(),
                    NextFireTime = trigger.GetNextFireTimeUtc(),
                    State = state.ToString(),
                    Type = "TODO!"
                };
            });

            await Task.WhenAll(result);

            return result
                .Select(x => x.Result)
                .ToList();
        }

        public async Task<bool> CreateTriggerAsync(
            string jobName,
            string jobGroupName,
            string triggerName,
            string triggerGroupName,
            string triggerDescription,
            bool startImmediately,
            string cronExpression,
            IDictionary<string, object> jobDataMap)
        {
            var trigger = CreateTrigger(triggerName, triggerGroupName, triggerDescription, startImmediately, cronExpression, jobDataMap);
            var jobDetail = await _scheduler.GetJobDetail(JobKey.Create(jobName, jobGroupName));
            await _scheduler.ScheduleJob(jobDetail, trigger);

            return true;
        }

        public async Task<bool> PauseTriggerAsync(string triggerName, string groupName)
        {
            await _scheduler.PauseTrigger(new TriggerKey(triggerName, groupName));
            return true;
        }

        public async Task<bool> DeleteTriggerAsync(string triggerName, string groupName)
        {
            var result = await _scheduler.UnscheduleJob(new TriggerKey(triggerName, groupName));
            return result;
        }

        public async Task<IDictionary<string, string>> GetJobDataMapAsync(string jobName, string groupName)
        {
            var jobDetail = await _scheduler.GetJobDetail(JobKey.Create(jobName, groupName));
            var jobDataMap = jobDetail.JobDataMap.ToDictionary(k => k.Key, v => v.Value.ToString());
            return jobDataMap;
        }

        private JobDataMap CreateJobDataMap(IDictionary<string, object> data)
        {
            var jobDataMap = new JobDataMap();

            if (data == null)
            {
                return jobDataMap;
            }

            var normalizedKeys = data.ToDictionary(k => k.Key.ToUpper(), v => v.Value);
            jobDataMap.PutAll(normalizedKeys);
            return jobDataMap;
        }

        private ITrigger CreateTrigger(
            string triggerName,
            string groupName,
            string description,
            bool startImmediately,
            string cronExpression,
            IDictionary<string, object> jobDataMap = null)
        {
            var triggerBuilder = TriggerBuilder
                .Create()
                .WithIdentity(triggerName, groupName)
                .WithDescription(description);

            if (jobDataMap != null)
            {
                var normalizedJobDataMap = CreateJobDataMap(jobDataMap);
                triggerBuilder = triggerBuilder.UsingJobData(normalizedJobDataMap);
            }

            if (!string.IsNullOrEmpty(cronExpression))
            {
                triggerBuilder = triggerBuilder.WithCronSchedule(cronExpression, x => x.InTimeZone(TimeZoneInfo.Utc));
            }

            if (startImmediately)
            {
                triggerBuilder = triggerBuilder.StartNow();
            }

            var trigger = triggerBuilder.Build();
            return trigger;
        }
    }
}
