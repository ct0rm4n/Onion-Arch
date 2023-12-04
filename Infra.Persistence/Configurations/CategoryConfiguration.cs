using Domain.Entities.Concrates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestrutura.Configurations
{
    public class CategoryConfiguration : BaseConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);
            builder
            .HasMany(e => e.Children)
            .WithOne(e => e.Parent)
            .HasForeignKey(e => e.ParentID)
           .OnDelete(DeleteBehavior.NoAction);



        }
    }
}
