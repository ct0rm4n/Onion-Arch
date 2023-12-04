using Application.Repositories;
using Domain.Entities.Concrates;
using Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositories
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<IEnumerable<Supplier>> GetSuppliersWithProducts()
        {
            List<Supplier> suppliers = await GetActivesAsIQueryable()
                .Include(x => x.ProductSuppliers)
                    .ThenInclude(x => x.Product)
                .ToListAsync();
            return suppliers;

        }
    }
}
