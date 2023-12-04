using Application.Repositories;
using Domain.Entities.Concrates;
using Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositories
{
    public class ProductSupplierRepository : GenericRepository<ProductSupplier>, IProductSupplierRepository
    {
        public ProductSupplierRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<IEnumerable<ProductSupplier>> GetProductSupplierWithProductAndSupplier()
        {
            List<ProductSupplier> productSuppliersWithProductAndSupplier = await GetActivesAsIQueryable()
                .Include(x => x.Product)
                .Include(x => x.Supplier)
                .ToListAsync();
            return productSuppliersWithProductAndSupplier;
        }
    }
}