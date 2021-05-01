using Autofac;
using Clockwerkz.Angular.Web.Constants;
using Clockwerkz.Angular.Web.Infrastructure;
using Clockwerkz.Domain;
using Clockwerkz.Infrastructure;
using Clockwerkz.Persistence;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace Clockwerkz.Angular.Web
{
    public class Startup
    {
        private IConfiguration _configuration { get; }

        public Startup(IWebHostEnvironment environment)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile($"{AppSettingsConfig.AppSettingsKey}.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"{AppSettingsConfig.QuartzSettingsKey}.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"{AppSettingsConfig.JobSettingsKey}.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"{AppSettingsConfig.AppSettingsKey}.{environment.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (environment.IsDevelopment())
            {
                configurationBuilder.AddUserSecrets<Startup>();
            }

            _configuration = configurationBuilder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration.GetConnectionString(AppSettingsConfig.QuartzDb);
            services.AddDbContext<IClockwerkzDbContext, ClockwerkzDbContext>(options => options.UseSqlServer(connectionString));

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddControllers();
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/octet-stream" });
            });

            services.AddMediatR(typeof(Startup).Assembly);
            services.AddSignalR();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacModule());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseResponseCompression();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<NotificationService>("/notificationService");                
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "api/{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
