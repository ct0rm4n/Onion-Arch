using Domain.Entities.Concrates;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestrutura.Configurations
{
    public class ProductFeatureConfiguration : BaseConfiguration<ProductFeature>
    {
        public override void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
        }

    }
}
