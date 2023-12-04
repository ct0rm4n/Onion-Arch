using Application.Repositories;
using AutoMapper;
using Domain.Entities.Concrates;
using ViewModels.ProductFeature;

namespace Services
{
    public class ProductFeatureService : GenericService<ProductFeatureSaveVM, ProductFeatureVM, ProductFeature>, IProductFeatureService
    {
        public ProductFeatureService(IGenericRepository<ProductFeature> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
