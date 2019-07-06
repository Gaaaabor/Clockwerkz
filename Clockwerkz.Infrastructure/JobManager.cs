using Clockwerkz.Application;
using Quartz;
using System;
using System.Collections.Generic;
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

        public async Task ScheduleCustomJob(string name, string groupName, bool startImmediately, string cronExpression, IDictionary<string, object> jobDataMap)
        {
            var job = JobBuilder
                .Create<IJob>()
                .WithIdentity(name, groupName)
                .UsingJobData(new JobDataMap(jobDataMap))
                .StoreDurably(true)
                .Build();

            var id = Guid.NewGuid().ToString();

            var trigger = TriggerBuilder
                .Create()
                .WithIdentity(id, groupName)
                .WithCronSchedule(cronExpression, x => x.InTimeZone(TimeZoneInfo.Utc));

            if (startImmediately)
            {
                trigger = trigger.StartNow();
            }

            await _scheduler.ScheduleJob(job, trigger.Build());
        }

        public async Task RemoveJob(string name, string groupName)
        {
            await _scheduler.DeleteJob(JobKey.Create(name, groupName));
        }

        public async Task Start()
        {
            await _scheduler.Start();
        }
    }
}
