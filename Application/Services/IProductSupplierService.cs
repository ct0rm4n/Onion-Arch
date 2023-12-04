using Domain.Entities.Concrates;
using ViewModels.ProductSupplier;
using Wrappers;

namespace Services
{
    public interface IProductSupplierService : IGenericService<ProductSupplierSaveVM,ProductSupplierVM,ProductSupplier>
    {
        public Task<Result<List<ProductSupplierVM>>> GetProductSupplierWithProductAndSupplier();

    }
}
