using ViewModels.Abstracts;
using ViewModels.Category;
using ViewModels.ProductFeature;
using ViewModels.ProductSupplier;
using ViewModels.Supplier;
using Domain.Enums;

namespace ViewModels.Product
{
    public class ImageVM : IBaseVM
    {
        public int Id { get; set; }
        public string Binary { get; set; } = string.Empty;
    }
}