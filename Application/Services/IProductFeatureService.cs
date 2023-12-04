using ViewModels.ProductFeature;
using Domain.Entities.Concrates;

namespace Services
{
    public interface IProductFeatureService : IGenericService<ProductFeatureSaveVM,ProductFeatureVM,ProductFeature>
    {
    }
}
