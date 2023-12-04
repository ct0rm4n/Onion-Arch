using ViewModels.Abstracts;
using ViewModels.ProductSupplier;

namespace ViewModels.Supplier
{
    public class SupplierVM : IBaseVM
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public List<ProductSupplierVM> ProductSupplierVMs { get; set; }

    }
}
