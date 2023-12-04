
using Domain.Entities.Abstarct;

namespace Domain.Entities.Concrates
{
    public class ProductFeature : BaseEntity, IEntity
    {
        public string MadeIn { get; set; }
        public DateTime RelaseDate { get; set; }

        //Relational Properties
        public Product Product { get; set; }
    }
}
