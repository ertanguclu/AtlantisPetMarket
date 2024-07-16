using EntityLayer.Config.Abstract;
using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Config.Concrete
{
    public class ProductConfig : BaseConfig<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.ProductName).HasMaxLength(50);
            builder.Property(p => p.Description).HasMaxLength(150);
            builder.Property(k => k.Price).HasPrecision(18, 2);

            builder.Property(u => u.ProductName).IsRequired();
            builder.Property(u => u.Brand).IsRequired();
            builder.Property(u => u.Price).IsRequired();


        }
    }
}
