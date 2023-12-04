using ViewModels.Abstracts;
using ViewModels.Category;
using ViewModels.ProductFeature;
using ViewModels.ProductSupplier;
using ViewModels.Supplier;
using Domain.Enums;

namespace ViewModels.Product
{
    public class ProductVM : IBaseVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public CategoryVM CategoryVM { get; set; }
        public ProductFeatureVM ProductFeatureVM { get; set; }
        public List<ProductSupplierVM> ProductSupplierVMs { get; set; }
    }
}