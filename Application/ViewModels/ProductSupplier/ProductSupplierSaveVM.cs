using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Abstracts;
using ViewModels.Product;
using ViewModels.Supplier;

namespace ViewModels.ProductSupplier
{
    public class ProductSupplierSaveVM : SaveVM
    {
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public bool isSelected { get; set; }
        public ProductVM ProductVM { get; set; }
        public SupplierVM SupplierVM { get; set; }
    }
}