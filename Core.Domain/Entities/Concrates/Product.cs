

using Domain.Entities.Abstarct;

namespace Domain.Entities.Concrates
{
    public class Product : BaseEntity, IEntity
    {
        public Product()
        {
            ProductSuppliers = new List<ProductSupplier>();
        }
        public string Name { get; set; }
        public int CategoryID { get; set; }

        //Relational Properties
        public Category Category { get; set; }
        public ProductFeature ProductFeature { get; set; }
        public ICollection<ProductSupplier> ProductSuppliers { get; set; }
    }
}