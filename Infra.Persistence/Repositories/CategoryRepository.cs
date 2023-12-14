using Application.Repositories;
using Core.Domain.Entities.Concrates.Catalog;
using Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositories
{
    internal class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }

        public async Task<Category> GetMainCategoryWithAllChildren()
        {
            Category? category = await GetActivesAsIQueryable()
                                       .Include(x => x.Children)
                                       .FirstOrDefaultAsync(x => x.ParentID == null);

            //foreach (Category child in category.Children)
            //    await LoadChildren(child);

            return category;
        }

        public async Task<Category> GetSpesificCategoryWithChildren(int id)
        {
            Category? category = await GetActivesAsIQueryable()
                                      .Include(x => x.Children)
                                      .FirstOrDefaultAsync(x => x.Id == id);

            //foreach (Category child in category.Children)
            //    await LoadChildren(child);

            return category;

        }

        public async Task<List<Category>> GetChildrensChildren(Category category)
        {
            return await GetActivesAsIQueryable()
                         .Include(x => x.Children)
                         .Where(x => x.ParentID == category.Id)
                         .ToListAsync();
        }

        //private async Task LoadChildren(Category category)
        //{
        //    category.Children = await GetActivesAsIQueryable()
        //                             .Include(x => x.Children)
        //                             .Where(x => x.ParentID == category.ID)
        //                             .ToListAsync();
        //    foreach (Category child in category.Children)
        //        await LoadChildren(child);
        //}
    }
}
