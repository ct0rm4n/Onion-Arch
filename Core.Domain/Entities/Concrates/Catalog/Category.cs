using Domain.Entities.Abstarct;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities.Concrates.Catalog
{
    public class Category : BaseEntity, IEntity
    {
        public string CategoryName { get; set; }
        [NotMapped]
        public int? ParentID { get; set; } = default(int?);

        [NotMapped]
        public ICollection<Product> Products { get; set; }
        [NotMapped]
        public virtual Category? Parent { get; set; }
        [NotMapped]
        public ICollection<Category>? Children { get; set; }

    }
}