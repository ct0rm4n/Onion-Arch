using Microsoft.Extensions.DependencyInjection;
using Mapping;

namespace DependencyResolvers
{
    public static class ServiceInjection
    {
        public static void AddApplicationLayerInjections(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapProfile));

        }
    }
}
