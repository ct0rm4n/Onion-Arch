using ViewModels.Supplier;
using Domain.Entities.Concrates;

namespace Services
{
    public interface ISupplierService : IGenericService<SupplierSaveVM, SupplierVM,Supplier>
    {
        public Task<SupplierListVM> GetSuppliersWithProducts();

    }
}
