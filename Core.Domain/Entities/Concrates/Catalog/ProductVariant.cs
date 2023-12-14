
using Domain.Entities.Abstarct;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Core.Domain.Entities.Concrates.Catalog;

public class ProductVariant : BaseEntity, IEntity
{
    [JsonIgnore]
    public Product? Product { get; set; }
    public int ProductId { get; set; }
    public ProductType? ProductType { get; set; }
    public int ProductTypeId { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal OriginalPrice { get; set; }
}
