using Domain.Entities.Abstarct;

namespace Core.Domain.Entities.Concrates.Catalog
{
    public class Image : BaseEntity, IEntity { 
        public string Binary { get; set; } = string.Empty;
    }
}


