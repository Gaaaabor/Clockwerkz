using Clockwerkz.Application.Jobs.Queries;
using Clockwerkz.Blazor.Web.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Clockwerkz.Blazor.Web.Configuration
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
