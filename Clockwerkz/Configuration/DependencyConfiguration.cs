using Clockwerkz.Application;
using Clockwerkz.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clockwerkz.Configuration
{
    public static class DependencyConfiguration
    {
        /// <summary>
        /// Registers interfaces with their implementations
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            //DI registrations
            services.AddTransient<IJobManager, JobManager>();
            services.AddTransient<IJobSettingsProvider, JobSettingsProvider>(x => new JobSettingsProvider(configuration));
        }
    }
}
