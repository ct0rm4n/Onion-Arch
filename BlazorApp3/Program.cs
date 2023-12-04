using Autofac.Extensions.DependencyInjection;
using Autofac;
using UI.Server.Components;
using DependencyResolvers.Autofac;
using DependencyResolvers;
using Microsoft.AspNetCore.Components.Authorization;
using UI.Server.Components.Account;
using Microsoft.AspNetCore.Identity;
using Domain.Entities.Concrates;
using Infraestrutura.Context;
using UI.Client.Pages;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddWebLayerInjections();
builder.Services.AddSession();
builder.Services.AddIdentityService();
builder.Services.AddApplicationLayerInjections();


//old - TODO
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
}).AddIdentityCookies();

builder.Services.AddIdentityCore<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AppDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();
builder.Services.AddBlazorBootstrap();//todo
builder.Services.AddSingleton<IEmailSender<AppUser>, IdentityNoOpEmailSender>();
//builder.Services.AddInfrastructureLayerInjections(builder.Configuration);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureServices(x => x.AddAutofac()).UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacPersistanceModule());
    builder.RegisterModule(new AutofacInnerInfrastructureModule());
});

WebApplication app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
   // app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
//app.UseAuthentication();//TODO

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();
app.Run();
