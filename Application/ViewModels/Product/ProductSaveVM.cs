using System.ComponentModel;
using ViewModels.Abstracts;
using ViewModels.Category;
using ViewModels.ProductFeature;
using ViewModels.ProductSupplier;
using ViewModels.Supplier;

namespace ViewModels.Product
{
    public class ProductSaveVM : SaveVM,IBaseVM
    {
        public ProductSaveVM()
        {
            SupplierVMs = new List<SupplierVM>();
            ProductSupplierVMs = new List<ProductSupplierVM>();
        }
        [DisplayName("Product Name")]
        public string Name { get; set; }
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        public List<int> SupplierIDs { get; set; }
        public List<CategoryVM>? CategoryVMs { get; set; }
        public List<SupplierVM>? SupplierVMs { get; set; }
        public List<ProductSupplierVM>? ProductSupplierVMs { get; set; }
        public List<ProductSupplierVM>? AllProductSupplierVMs { get; set; }
        public ProductFeatureSaveVM? ProductFeatureSaveVM { get; set; }

    }
}