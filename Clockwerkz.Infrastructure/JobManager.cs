using Clockwerkz.Application;
using Microsoft.Extensions.Logging;
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

        public async Task CreateJobAsync()
        {
            var jobs = new Dictionary<IJobDetail, IReadOnlyCollection<ITrigger>>();

            var now = DateTime.Now;

            for (int i = 1; i <= 100; i++)
            {
                var groupName = $"Group_{i % 4}";

                //TODO: implement
                var job = JobBuilder
                    .Create<IIdleJob>()
                    .WithIdentity($"Job_{i}", groupName)
                    .StoreDurably(true)
                    .Build();

                var id = Guid.NewGuid().ToString();
                var trigger = TriggerBuilder
                    .Create()
                    .WithIdentity(id, id)
                    .WithSimpleSchedule(x => x.WithIntervalInMinutes(1))                    
                    .StartAt(now.AddSeconds(i))
                    .Build();

                jobs.Add(job, new[] { trigger });
            }            

            await _scheduler.ScheduleJobs(jobs, false);
        }

        public async Task RemoveJob(string name, string groupName)
        {
            await _scheduler.DeleteJob(JobKey.Create(name, groupName));
        }

        public async Task Start()
        {
            await _scheduler.Start();
        }
        public interface IIdleJob : IJob
        {
        }

        [DisallowConcurrentExecution]
        public class IdleJob : IIdleJob
        {
            private readonly ILogger _logger;

            public IdleJob(ILogger logger)
            {
                _logger = logger;
            }

            public async Task Execute(IJobExecutionContext context)
            {
                _logger.LogInformation($"{nameof(IdleJob)} is successfully executed!");
                await Task.CompletedTask;
            }
        }
    }
}
