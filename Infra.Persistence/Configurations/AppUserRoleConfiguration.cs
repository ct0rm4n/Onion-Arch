using Domain.Entities.Concrates;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestrutura.Configurations
{
    public class AppUserRoleConfiguration : BaseConfiguration<AppUserRole>
    {
        public override void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            base.Configure(builder);
        }
    }
}
