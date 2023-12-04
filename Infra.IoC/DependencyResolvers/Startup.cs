using Domain.Entities.Concrates;
using Infraestrutura.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Services.Account;

namespace Infra.IoC.DependencyResolvers
{
    public class StartupInject
    {
        public void Configure(IApplicationBuilder app)
        {
            throw new NotImplementedException();
        }

        public void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IdentityUserAccessor>();
            builder.Services.AddScoped<IdentityRedirectManager>();
            builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();
            builder.Services.AddScoped<IEmailSender<AppUser>, IdentityNoOpEmailSender>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            }).AddIdentityCookies();

            builder.Services.AddIdentityCore<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<AppDbContext>().AddSignInManager().AddDefaultTokenProviders();
        }
        public void BuildMain(WebApplication app)
        {
            app.MapAdditionalIdentityEndpoints();
        }
        
    }
}
