using ViewModels.Category;
using Core.Domain.Entities.Concrates.Catalog;

namespace Services
{
    public interface ICategoryService : IGenericService<CategorySaveVM, CategoryVM, Category>
    {
        public Task<List<CategoryVM>> GetCategories();//redundant
        public Task<CategoryVM> GetCategoriesWithChildren();
        public Task<Category> GetCategoryWithChildren(int id);
        public Task GetChildrensChildren(Category category);
    }
}
