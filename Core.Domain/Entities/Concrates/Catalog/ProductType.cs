using Domain.Entities.Abstarct;

namespace Core.Domain.Entities.Concrates.Catalog;

public class ProductType : BaseEntity, IEntity
{
    public string Name { get; set; } = string.Empty;

}
