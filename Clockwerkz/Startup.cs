using Autofac;
using Clockwerkz.Common;
using Clockwerkz.Configuration;
using Clockwerkz.Filters;
using Clockwerkz.Infrastructure;
using Clockwerkz.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            builder.AddUserSecrets<Startup>();

            _configuration = builder.Build();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacModule());
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            // Add DbContext using SQL Server Provider
            services.AddDbContext<ClockwerkzDbContext>(x => x.UseSqlServer(_configuration.GetConnectionString(AppsettingsConfig.QuartzDb)));

            // Mvc + Custom Exception Filter
            services.AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)));
            services.ConfigureMediatR();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = AppsettingsConfig.ConfigurationRootPath;
            });

            services.ConfigureQuartz(_configuration);
            services.ConfigureAuth0(_configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseSpaStaticFiles();

            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
