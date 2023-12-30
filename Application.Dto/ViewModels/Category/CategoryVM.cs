using System.ComponentModel.DataAnnotations.Schema;
using ViewModels.Abstracts;
using ViewModels.Product;

namespace ViewModels.Category
{
    public class CategoryVM :IBaseVM
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        [NotMapped]
        public int? ParentID { get; set; } = default(int?);

        //[NotMapped]
        //public ICollection<Product> Products { get; set; }
        //[NotMapped]
        //public virtual Category? Parent { get; set; }
        //[NotMapped]
        //public ICollection<Category>? Children { get; set; }
    }
}