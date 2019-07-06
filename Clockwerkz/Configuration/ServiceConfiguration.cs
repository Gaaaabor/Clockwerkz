using Clockwerkz.Application.Jobs.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Clockwerkz.Configuration
{
    public static class ServiceConfiguration
    {
        public static void ConfigureMediatR(this IServiceCollection services)
        {
            // Add framework services.
            // Add MediatR
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR(typeof(ListJobDetailsQueryHandler).GetTypeInfo().Assembly);

            // Add Open API support (will generate specification document)
            //services.AddSwagger();

            // Add Logging + Seq
            //services.AddLogging(loggingBuilder => { loggingBuilder.AddSeq(); });            

            // Customise default API behavour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }
    }
}
