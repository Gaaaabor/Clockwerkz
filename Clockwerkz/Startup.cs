using Autofac;
using Clockwerkz.Application;
using Clockwerkz.Common;
using Clockwerkz.Configuration;
using Clockwerkz.Domain;
using Clockwerkz.Filters;
using Clockwerkz.Infrastructure;
using Clockwerkz.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Clockwerkz
{
    public class Startup
    {
        private const string AppSettingsKey = "appsettings";
        private const string QuartzSettingsKey = "quartzsettings";

        private IConfiguration _configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile($"{AppSettingsKey}.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"{QuartzSettingsKey}.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"{AppSettingsKey}.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            _configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.OutputFormatters.RemoveType<StringOutputFormatter>();
            });

            // Add DbContext using SQL Server Provider
            services.AddDbContext<IClockwerkzDbContext, ClockwerkzDbContext>(x => x.UseSqlServer(_configuration.GetConnectionString(AppsettingsConfig.QuartzDb)));

            // Mvc + Custom Exception Filter
            services.AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)));

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = AppsettingsConfig.ConfigurationRootPath;
            });

            services.ConfigureQuartz(_configuration);
            services.ConfigureMediatR();
            services.ConfigureAuth0(_configuration);

            //DI registrations
            services.AddTransient<IJobManager, JobManager>();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                    HotModuleReplacementClientOptions = new Dictionary<string, string> { { "reload", "true" } },
                    ReactHotModuleReplacement = true,
                    ConfigFile = "webpack.config.js"
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
