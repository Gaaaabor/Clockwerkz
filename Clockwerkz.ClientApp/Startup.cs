
using Autofac;
using Clockwerkz.ClientApp.Configuration;
using Clockwerkz.ClientApp.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Clockwerkz.ClientApp
{
    public class Startup
    {
        private const string AppSettingsKey = "appsettings";
        private const string QuartzSettingsKey = "quartzsettings";
        private const string JobSettingsKey = "jobsettings";

        private readonly IConfiguration _configuration;

        public Startup(IWebHostEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile($"{AppSettingsKey}.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"{QuartzSettingsKey}.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"{JobSettingsKey}.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"{AppSettingsKey}.{environment.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (environment.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            _configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.ConfigureQuartz(_configuration);
            services.ConfigureMediatR();
            services.ConfigureAuth0(_configuration);
            services.ConfigureDependencyInjection(_configuration);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
