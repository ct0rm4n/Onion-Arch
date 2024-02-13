using API.HangFire.Scheduler;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using DependencyResolvers.Autofac;
using Hangfire;
using DependencyResolvers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHangfire(configuration => configuration
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
        .UseSimpleAssemblyNameTypeSerializer()
.UseRecommendedSerializerSettings()
        .UseSqlServerStorage(builder.Configuration.GetConnectionString("HangFireConnection")));

builder.Services.AddHangfireServer();
builder.Services.AddApplicationLayerInjections();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureServices(x => x.AddAutofac()).UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacPersistanceModule());
    builder.RegisterModule(new AutofacInnerInfrastructureModule());
});


var app = builder.Build();

app.UseHttpsRedirection();

app.UseHangfireDashboard();

RecurringJob.AddOrUpdate("Currency BackGround Jobs",
    () => new Scheduler().Run(), Cron.Daily);

app.Run();
