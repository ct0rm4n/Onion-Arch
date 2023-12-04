using Domain.Entities.Abstarct;

namespace Domain.Entities.Concrates
{
    public class Category : BaseEntity, IEntity
    {
        public string CategoryName { get; set; }
        public int? ParentID { get; set; }

        //Relational Properties
        public ICollection<Product> Products { get; set; }
        public  Category? Parent { get; set; }

        public  ICollection<Category> Children { get; set; }

    }
}