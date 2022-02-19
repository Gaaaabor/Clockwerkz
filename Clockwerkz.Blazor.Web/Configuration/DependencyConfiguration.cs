using Clockwerkz.Application;
using Clockwerkz.Application.Interfaces;
using Clockwerkz.Blazor.Web.Constants;
using Clockwerkz.Domain;
using Clockwerkz.Infrastructure;
using Clockwerkz.Infrastructure.Jobs;
using Clockwerkz.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clockwerkz.Blazor.Web.Configuration
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
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IJobSettingsProvider, JobSettingsProvider>(x => new JobSettingsProvider(configuration));            

            services.AddScoped<HttpClient>();

            // Add DbContext using SQL Server Provider
            services.AddDbContext<IClockwerkzDbContext, ClockwerkzDbContext>(x => x.UseSqlServer(configuration.GetConnectionString(AppSettingsConfig.QuartzDb)));
        }
    }
}
