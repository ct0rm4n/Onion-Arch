using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using ViewModels.Abstracts;
using ViewModels.Product;

namespace Application.Dto.ViewModels.Product
{
    public class ProductVariantVM : IBaseVM
    {
        [JsonIgnore]
        public ProductVM? Product { get; set; }
        public int ProductId { get; set; }
        public ProductTypeVM? ProductType { get; set; }
        public int ProductTypeId { get; set; }

        public decimal Price { get; set; }

        public decimal OriginalPrice { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public bool Editing { get; set; } = false;
        public bool IsNew { get; set; } = false;
    }
}
