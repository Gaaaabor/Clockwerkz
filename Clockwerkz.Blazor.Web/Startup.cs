using Clockwerkz.Blazor.Web.Configuration;
using Clockwerkz.Blazor.Web.Constants;
using Clockwerkz.Domain;
using Clockwerkz.Infrastructure;
using Clockwerkz.Persistence;
using MediatR;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

namespace Clockwerkz.Blazor.Web
{
    public static class Startup
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            var connectionString = configuration.GetValue<string>(AppSettingsConfig.QuartzDb);
            services.AddDbContext<IClockwerkzDbContext, ClockwerkzDbContext>(options => options.UseSqlServer(connectionString));

            services.AddControllers();
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/octet-stream" });
            });

            services.AddMediatR(typeof(Startup).Assembly);
            services.AddSignalR();

            services.ConfigureAuth0(configuration);
            services.ConfigureDependencyInjection(configuration);
            services.ConfigureQuartz(configuration);
            services.ConfigureMediatR();
        }

        public static void Configure(this WebApplication app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.UseResponseCompression();
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<NotificationService>("/notificationService");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "api/{controller}/{action=Index}/{id?}");
            });
        }
    }
}
