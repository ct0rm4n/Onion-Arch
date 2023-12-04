﻿using Domain.Entities.Concrates;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestrutura.Configurations
{
    public class ProductSupplierConfiguration : BaseConfiguration<ProductSupplier>
    {
        public override void Configure(EntityTypeBuilder<ProductSupplier> builder)
        {
            base.Configure(builder);
            builder.Ignore(x => x.Id);
            builder.HasKey(x =>new
            {
                x.ProductId,
                x.SupplierId
            });
        }
    }
}