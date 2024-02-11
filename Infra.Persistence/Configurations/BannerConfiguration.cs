using Core.Domain.Entities.Concrates.Catalog;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestrutura.Configurations
{
    public class BannerConfiguration : BaseConfiguration<Banner>
    {
        public override void Configure(EntityTypeBuilder<Banner> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
        }

    }
}
