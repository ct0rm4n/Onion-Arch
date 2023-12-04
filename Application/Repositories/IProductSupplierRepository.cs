
using Application.Repositories;
using Domain.Entities.Concrates;

namespace Application.Repositories
{
    public interface IProductSupplierRepository : IGenericRepository<ProductSupplier>
    {
        //        public Task<IEnumerable<Product>> GetProductsWithCategory();

        public Task<IEnumerable<ProductSupplier>> GetProductSupplierWithProductAndSupplier();
    }
}
