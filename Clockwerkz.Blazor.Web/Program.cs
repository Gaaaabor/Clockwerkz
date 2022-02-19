using Autofac;
using Autofac.Extensions.DependencyInjection;
using Clockwerkz.Blazor.Web;
using Clockwerkz.Blazor.Web.Constants;
using Clockwerkz.Blazor.Web.Infrastructure;
using Clockwerkz.Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile($"{AppSettingsConfig.QuartzSettingsKey}.json", optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile($"{AppSettingsConfig.JobSettingsKey}.json", optional: false, reloadOnChange: true);
builder.Configuration.AddEnvironmentVariables();

builder.Services.ConfigureServices(builder.Configuration);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacModule()));

var app = builder.Build();

app.Configure(builder.Environment);

app.Run();
