using ViewModels.Category;
using Domain.Entities.Concrates;

namespace Services
{
    public interface ICategoryService : IGenericService<CategorySaveVM, CategoryVM, Category>
    {
        public Task<CategoryListVM> GetCategories();//redundant
        public Task<CategoryVM> GetCategoriesWithChildren();
        public Task<Category> GetCategoryWithChildren(int id);
        public Task GetChildrensChildren(Category category);
    }
}
