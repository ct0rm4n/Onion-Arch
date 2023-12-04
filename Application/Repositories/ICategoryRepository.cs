
using Application.Repositories;
using Domain.Entities.Concrates;

namespace Application.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        public Task<Category> GetMainCategoryWithAllChildren();        
        public Task<Category> GetSpesificCategoryWithChildren(int id);
        public Task<List<Category>> GetChildrensChildren(Category category);

    }
}