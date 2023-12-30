using Application.Dto.ViewModels.Product;
using Core.Domain.Entities.Concrates.Catalog;

namespace Services
{
    public interface IProductTypeService : IGenericService<ProductTypeSaveVM, ProductTypeVM, ProductType>
    {
        public List<ProductTypeVM> ProductTypes { get; set; }
        public Task GetProductTypes();
    }
}
