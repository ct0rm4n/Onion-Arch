using Domain.Entities.Concrates;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestrutura.Configurations
{
    public class ToDoConfiguration : BaseConfiguration<ToDo>
    {
        public override void Configure(EntityTypeBuilder<ToDo> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
        }
    }
}
