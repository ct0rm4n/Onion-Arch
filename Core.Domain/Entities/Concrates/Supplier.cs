using Domain.Entities.Abstarct;

namespace Domain.Entities.Concrates
{
    public class Supplier : BaseEntity, IEntity
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }

        //Relational Properties
        public ICollection<ProductSupplier> ProductSuppliers { get; set; }
    }
}