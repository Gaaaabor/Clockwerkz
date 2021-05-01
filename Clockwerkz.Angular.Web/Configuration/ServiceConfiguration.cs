using Clockwerkz.Angular.Web.Infrastructure;
using Clockwerkz.Application.Jobs.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Clockwerkz.Angular.Web.Configuration
{
    public static class ServiceConfiguration
    {
        public static void ConfigureMediatR(this IServiceCollection services)
        {
            // Add framework services.
            // Add MediatR
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>)); //TODO implement
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>)); //TODO implement
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR(typeof(ListJobsQueryHanlder).GetTypeInfo().Assembly);

            // Add Open API support (will generate specification document)
            services.AddSwaggerDocument();

            // Add Logging
            services.AddLogging();

            // Customise default API behavour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }
    }
}
