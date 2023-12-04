using Domain.Entities.Concrates;

namespace Application.Repositories
{
    public interface ISupplierRepository : IGenericRepository<Supplier>
    {
        public Task<IEnumerable<Supplier>> GetSuppliersWithProducts();
    }
}
