using Domain.Entities.Concrates;
using Infraestrutura.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Services.Account;

namespace Infra.IoC.DependencyResolvers
{
    public static class StartupInject
    {
        public static void InjectConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<UserManager<AppUser>>();
            builder.Services.AddScoped<SignInManager<AppUser>>();
            builder.Services.AddScoped<RoleManager<AppRole>>();

            builder.Services.AddScoped<IdentityUserAccessor>();
            builder.Services.AddScoped<IdentityRedirectManager>();
            builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();
            builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();
            builder.Services.AddScoped<IEmailSender<AppUser>, IdentityNoOpEmailSender>();
            
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            }).AddIdentityCookies();

            builder.Services.AddIdentityCore<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<AppDbContext>().AddSignInManager().AddDefaultTokenProviders();
        }
        public static void BuildMain(this WebApplication app)
        {
            app.MapAdditionalIdentityEndpoints();
        }
        
    }
}
