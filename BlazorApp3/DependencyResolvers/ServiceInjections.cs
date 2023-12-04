using Filters;
using FluentValidation;
using FluentValidation.AspNetCore;
using Validators;

namespace DependencyResolvers
{
    public static class ServiceInjections
    {
        public static void AddWebLayerInjections(this IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddValidatorsFromAssemblyContaining<ProductSaveVMValidator>();


            services.AddScoped(typeof(NotFoundFilter<,,>));

        }
    }
}
