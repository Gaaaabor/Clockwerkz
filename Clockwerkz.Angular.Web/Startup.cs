using Clockwerkz.Angular.Web.Constants;
using Clockwerkz.Domain;
using Clockwerkz.Persistence;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Clockwerkz.Angular.Web
{
    public class Startup
    {
        private IConfiguration _configuration { get; }

        public Startup(IWebHostEnvironment env)
        {
            var configurationBuilder = new ConfigurationBuilder();

            if (string.Equals(env.EnvironmentName, Environments.Development, StringComparison.OrdinalIgnoreCase))
            {
                configurationBuilder.AddUserSecrets<Startup>();
            }

            //configurationBuilder.AddJsonFile(string.Format(AppSettingsConfig.AppSettingsFileFormat, env.EnvironmentName), false, true);
            //configurationBuilder.AddJsonFile(AppSettingsConfig.JobSettingsFileName, false, true);

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

            services.AddMediatR(typeof(Startup).Assembly);
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
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
