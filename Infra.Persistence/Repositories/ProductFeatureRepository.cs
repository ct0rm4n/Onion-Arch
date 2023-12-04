
using Application.Repositories;
using Domain.Entities.Concrates;
using Infraestrutura.Context;

namespace Infraestrutura.Repositories
{
    public class ProductFeatureRepository : GenericRepository<ProductFeature>, IProductFeatureRepository
    {
        public ProductFeatureRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
