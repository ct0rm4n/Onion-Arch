using Application.Repositories;
using AutoMapper;
using Core.Domain.Entities.Concrates.Catalog;
using Service.Interface.ViewModels.Product;
using Services;
namespace Service.Application.Services
{
    public class ProductTypeService : GenericService<ProductTypeSaveVM, ProductTypeVM, ProductType>, IProductTypeService
    {
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly ICategoryService _categoryService;

        public ProductTypeService(IGenericRepository<ProductType> repository, IMapper mapper, IProductTypeRepository productTypeRepository, ICategoryService categoryService) : base(repository, mapper)
        {
            _productTypeRepository = productTypeRepository;

            _categoryService = categoryService;
        }

        public List<ProductTypeVM> ProductTypes { get; set; } = new List<ProductTypeVM>();
        

        public async Task GetProductTypes()
        {
            
        }
    }
}