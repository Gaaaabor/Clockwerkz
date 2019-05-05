using Clockwerkz.Application;
using Clockwerkz.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz.Impl;
using System.Collections.Specialized;

namespace Clockwerkz.Configuration
{
    public static class QuartzConfiguration
    {
        private const string SerializerType = StdSchedulerFactory.PropertyObjectSerializer + ".type";
        private const string JobStoreType = StdSchedulerFactory.PropertyJobStorePrefix + ".type";
        private const string JobStoreUseProperties = StdSchedulerFactory.PropertyJobStorePrefix + ".useProperties";
        private const string JobStoreDataSource = StdSchedulerFactory.PropertyJobStorePrefix + ".dataSource";
        private const string JobStoreTablePrefix = StdSchedulerFactory.PropertyJobStorePrefix + ".tablePrefix";
        private const string JobStoreMisFireThreshold = StdSchedulerFactory.PropertyJobStorePrefix + ".misfireThreshold";
        private const string JobStoreDriverDelegateType = StdSchedulerFactory.PropertyJobStorePrefix + ".driverDelegateType";
        private const string JobStoreLockHandlerType = StdSchedulerFactory.PropertyJobStorePrefix + ".lockHandler.type";
        private const string DataSourceDefaultProvider = StdSchedulerFactory.PropertyDataSourcePrefix + ".default.provider";
        private const string DataSourceConnectionString = StdSchedulerFactory.PropertyDataSourcePrefix + ".default.connectionString";
        private const string ThreadPoolThreadCount = StdSchedulerFactory.PropertyThreadPoolPrefix + ".threadCount";
        private const string ThreadPoolThreadPriority = StdSchedulerFactory.PropertyThreadPoolPrefix + ".threadPriority";

        public static void ConfigureQuartz(this IServiceCollection services, IConfiguration configuration)
        {
            //DI registrations
            services.AddTransient<IJobManager, JobManager>();

            services.AddTransient(async x =>
            {
                var config = configuration.GetQuartzConfig();
                var factory = new StdSchedulerFactory(config);
                return await factory.GetScheduler("ClockwerkzScheduler");

            });
        }

        private static NameValueCollection GetQuartzConfig(this IConfiguration configuration)
        {
            return new NameValueCollection
            {
                // json serialization is the one supported under .NET Core (binary isn't)
                [SerializerType] = configuration[SerializerType.ToConfigKey()],

                // the following setup of job store is just for example and it didn't change from v2
                [JobStoreType] = configuration[JobStoreType.ToConfigKey()],
                [JobStoreUseProperties] = configuration[JobStoreUseProperties.ToConfigKey()],
                [JobStoreDataSource] = configuration[JobStoreDataSource.ToConfigKey()],
                [JobStoreTablePrefix] = configuration[JobStoreTablePrefix.ToConfigKey()],
                [JobStoreMisFireThreshold] = configuration[JobStoreMisFireThreshold.ToConfigKey()],
                [JobStoreDriverDelegateType] = configuration[JobStoreDriverDelegateType.ToConfigKey()],
                [JobStoreLockHandlerType] = configuration[JobStoreLockHandlerType.ToConfigKey()],

                [DataSourceDefaultProvider] = configuration[DataSourceDefaultProvider.ToConfigKey()],
                [DataSourceConnectionString] = configuration[DataSourceConnectionString.ToConfigKey()],

                [StdSchedulerFactory.PropertySchedulerInstanceName] = configuration[StdSchedulerFactory.PropertySchedulerInstanceName.ToConfigKey()],
                [StdSchedulerFactory.PropertySchedulerInstanceId] = configuration[StdSchedulerFactory.PropertySchedulerInstanceId.ToConfigKey()],
                [StdSchedulerFactory.PropertyThreadPoolType] = configuration[StdSchedulerFactory.PropertyThreadPoolType.ToConfigKey()],
                [ThreadPoolThreadCount] = configuration[ThreadPoolThreadCount.ToConfigKey()],
                [ThreadPoolThreadPriority] = configuration[ThreadPoolThreadPriority.ToConfigKey()]
            };
        }

        private static string ToConfigKey(this string key)
        {
            return key.Replace('.', ':');
        }
    }
}
