using Domain.Entities.Concrates;
using Infraestrutura.Context;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyResolvers
{
    public static class IdentityConfiguration
    {
        public static void AddIdentityService(this IServiceCollection services)
        {
            services.AddIdentityCore<AppUser>(
                x =>
                {
                    x.Password.RequireDigit = false;
                    x.Password.RequireLowercase = false;
                    x.Password.RequireUppercase = false;
                    x.Password.RequireNonAlphanumeric = false;
                    x.Password.RequiredLength = 3;
                    x.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                    x.User.RequireUniqueEmail = true;
                    x.SignIn.RequireConfirmedEmail = false;
                })
                .AddEntityFrameworkStores<AppDbContext>();
                //.AddDefaultTokenProviders();
        }
    }
}
