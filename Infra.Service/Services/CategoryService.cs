using AutoMapper;
using Application.Repositories;
using ViewModels.Category;
using Core.Domain.Entities.Concrates.Catalog;

namespace Services
{
    public class CategoryService : GenericService<CategorySaveVM, CategoryVM, Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(IGenericRepository<Category> repository, IMapper mapper, ICategoryRepository categoryRepository) : base(repository, mapper)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryVM>> GetCategories()//redundant
        {
            List<CategoryVM> categorVMs = new List<CategoryVM>();
            var categories = _categoryRepository.GetAllAsIQueryable().ToList();;
            foreach (var itemEntity in categories)
            {
                categorVMs.Add(_mapper.Map<CategoryVM>(itemEntity));
            }
            return categorVMs;
        }

        public async Task<CategoryVM> GetCategoriesWithChildren()
        {
            Category category = (await _categoryRepository.GetMainCategoryWithAllChildren());
            foreach (Category child in category.Children)
                await GetChildrensChildren(child);

            CategoryVM categoryVM = _mapper.Map<CategoryVM>(category);

            return categoryVM;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">PARENT ID</param>
        /// <returns></returns>
        public async Task<Category> GetCategoryWithChildren(int id)
        {
            Category category = (await _categoryRepository.GetSpesificCategoryWithChildren(id));
            foreach (Category child in category.Children)
                await GetChildrensChildren(child);


            return category;
        }
        public async Task GetChildrensChildren(Category category)
        {
            category.Children = await _categoryRepository.GetChildrensChildren(category);
            foreach (Category child in category.Children)
                await GetChildrensChildren(child);
        }

    }
}