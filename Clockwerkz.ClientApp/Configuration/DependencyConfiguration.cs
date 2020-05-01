using Clockwerkz.Application;
using Clockwerkz.ClientApp.Common;
using Clockwerkz.Domain;
using Clockwerkz.Infrastructure;
using Clockwerkz.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clockwerkz.ClientApp.Configuration
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
            services.AddTransient<IMediator, Mediator>();
            services.AddTransient<IJobManager, JobManager>();
            services.AddTransient<IJobSettingsProvider, JobSettingsProvider>(x => new JobSettingsProvider(configuration));

            // Add DbContext using SQL Server Provider
            services.AddDbContext<IClockwerkzDbContext, ClockwerkzDbContext>(x => x.UseSqlServer(configuration.GetConnectionString(AppsettingsConfig.QuartzDb)));
        }
    }
}
