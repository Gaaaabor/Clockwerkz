using Clockwerkz.Application;
using Clockwerkz.Application.Jobs.Models;
using Quartz;
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

        public async Task Start()
        {
            await _scheduler.Start();
        }

        public async Task<JobListDto> ScheduleCustomJobAsync(string jobName, string groupName, bool startImmediately, string cronExpression, IDictionary<string, object> jobDataMap)
        {
            var normalizedJobData = NormalizeKeys(jobDataMap);

            var job = JobBuilder
                .Create<IJob>()
                .WithIdentity(jobName, groupName)
                .UsingJobData(normalizedJobData)
                .StoreDurably(true)
                .Build();

            var triggerName = Guid.NewGuid().ToString();

            var triggerBuilder = TriggerBuilder
                .Create()
                .WithIdentity(triggerName, groupName);

            if (cronExpression != null)
            {
                triggerBuilder.WithCronSchedule(cronExpression, x => x.InTimeZone(TimeZoneInfo.Utc));

                if (startImmediately)
                {
                    triggerBuilder = triggerBuilder.StartNow();
                }
            }

            var trigger = triggerBuilder.Build();
            await _scheduler.ScheduleJob(job, trigger);

            var triggerState = await _scheduler.GetTriggerState(trigger.Key);

            var jobListDto = Map(trigger, triggerState);

            return jobListDto;
        }

        public async Task DeleteJobAsync(string name, string groupName)
        {
            await _scheduler.DeleteJob(JobKey.Create(name, groupName));
        }

        public async Task DeleteTriggerAsync(string name, string groupName)
        {
            await _scheduler.UnscheduleJob(new TriggerKey(name, groupName));
        }

        private JobDataMap NormalizeKeys(IDictionary<string, object> jobDataMap)
        {
            var upperKeyedDict = jobDataMap.ToDictionary(k => k.Key.ToUpper(), v => v.Value?.ToString());
            return new JobDataMap(upperKeyedDict);
        }

        private JobListDto Map(ITrigger trigger, TriggerState triggerState)
        {
            return new JobListDto
            {
                JobName = trigger.JobKey.Name,
                JobGroup = trigger.JobKey.Group,
                TriggerGroup = trigger.Key.Group,
                TriggerName = trigger.Key.Name,                
                State = triggerState.ToString(),
                StartTime = trigger.StartTimeUtc.Ticks,
                EndTime = trigger.EndTimeUtc?.Ticks,
                PreviousFireTime = trigger.GetPreviousFireTimeUtc()?.Ticks,
                NextFireTime = trigger.GetNextFireTimeUtc()?.Ticks
            };
        }
    }
}
