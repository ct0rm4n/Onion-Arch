using Application.Repositories;
using Core.Domain.Entities.Concrates.Catalog;
using Domain.Enums;
using Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<Product> GetProduct(int id)
        {
            Product? product = await GetActivesAsIQueryable().FirstOrDefaultAsync(x=>x.Id ==id);
                //.Include(x => x.Category)
                //.Include(x => x.ProductFeature)
                //.Include(x => x.ProductSuppliers)
                //    .ThenInclude(x => x.Supplier)
                //.FirstOrDefaultAsync(x=>x.Id==id);

            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            List<Product> products = await GetActivesAsIQueryable()
                .Include(x=>x.Category)
                .Where(x => x.Category.Status != Status.Deleted)
                //.Include(x=>x.ProductFeature)
                //.Include(x=>x.ProductSuppliers)
                //    .ThenInclude(x => x.Supplier)
                .ToListAsync();

            return products;
        }

        public async Task<IEnumerable<Product>> GetProductsByCount(int count)
        {
            List<Product> products = await GetActivesAsIQueryable()
                .Include(x => x.Category)
                .Where(x => x.Category.Status != Status.Deleted)
                //.Include(x => x.ProductFeature)
                //.Include(x => x.ProductSuppliers)
                //    .ThenInclude(x => x.Supplier)
                .OrderByDescending(x=>x.InsertedDate)
                .Take(count)
                .ToListAsync();

            return products;
        }

        
    }
}