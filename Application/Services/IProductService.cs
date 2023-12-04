using Domain.Entities.Concrates;
using ViewModels.Product;
using Wrappers;

namespace Services
{
    public interface IProductService : IGenericService<ProductSaveVM, ProductVM, Product>
    {
        public Task<ProductListVM> GetProducts();
        public Task<Result<ProductSaveVM>> GetProduct(int id);
        public Task<ProductListVM> GetProductsByCount(int count);


    }
}
