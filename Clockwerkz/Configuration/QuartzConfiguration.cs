using Clockwerkz.Application;
using Clockwerkz.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Quartz.Impl;
using System.Collections.Specialized;

namespace Clockwerkz.Configuration
{
    public static class QuartzConfiguration
    {
        public static void ConfigureQuartz(this IServiceCollection services)
        {
            //DI registrations
            services.AddTransient<IJobManager, JobManager>();

            services.AddTransient(async x =>
            {
                var properties = new NameValueCollection
                {

                    // json serialization is the one supported under .NET Core (binary isn't)
                    ["quartz.serializer.type"] = "json",

                    // the following setup of job store is just for example and it didn't change from v2
                    [StdSchedulerFactory.PropertyJobStoreType] = "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz",
                    ["quartz.jobStore.useProperties"] = "true",
                    ["quartz.jobStore.dataSource"] = "default",
                    ["quartz.jobStore.tablePrefix"] = "QRTZ_",
                    ["quartz.jobStore.misfireThreshold"] = "60000",
                    ["quartz.jobStore.driverDelegateType"] = "Quartz.Impl.AdoJobStore.SqlServerDelegate, Quartz",
                    ["quartz.jobStore.lockHandler.type"] = "Quartz.Impl.AdoJobStore.UpdateLockRowSemaphore, Quartz",

                    ["quartz.dataSource.default.provider"] = "SqlServer",// "SqlServer-41", // SqlServer-41 is the new provider for .NET Core
                    ["quartz.dataSource.default.connectionString"] = @"Server=(localdb)\MSSQLLOCALDB;Database=QuartzDb;Integrated Security=true",

                    ["quartz.scheduler.instanceName"] = "ClockwerkzScheduler",
                    ["quartz.scheduler.instanceId"] = "7B89E80C-9042-4896-8CEA-2C61CBE7E89F",

                    ["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz",
                    ["quartz.threadPool.threadCount"] = "10",
                    ["quartz.threadPool.threadPriority"] = "Normal"
                };

                var factory = new StdSchedulerFactory(properties);
                return await factory.GetScheduler("ClockwerkzScheduler");

            });
        }
    }
}
