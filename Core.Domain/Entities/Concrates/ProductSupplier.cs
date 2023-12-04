using Domain.Entities.Abstarct;

namespace Domain.Entities.Concrates
{
    public class ProductSupplier :  BaseEntity, IEntity
    {
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        
        //Relational Properties
        public Product Product { get; set; }
        public Supplier Supplier { get; set; }
    }
}
