using ViewModels.Abstracts;
using ViewModels.Category;
using System.ComponentModel.DataAnnotations;
using Application.Dto.ViewModels.Product;

namespace ViewModels.Product
{
    public class ProductVM : IBaseVM
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public List<ImageVM> Images { get; set; } = new List<ImageVM>();
        public CategoryVM? Category { get; set; }
        public int CategoryId { get; set; }
        public bool Featured { get; set; } = false;
        public List<ProductVariantVM> Variants { get; set; } = new List<ProductVariantVM>();
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public bool Editing { get; set; } = false;
        public bool IsNew { get; set; } = false;
    }
}