using EntityLayer.Config.Abstract;
using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityLayer.Config.Concrete
{
    public class ProductConfig : BaseConfig<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.ProductName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Brand).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(150);
            builder.Property(k => k.Price).IsRequired().HasPrecision(18, 2);
            builder.Property(p => p.ProductCode).IsRequired().HasMaxLength(50);
            builder.Property(p => p.StockQuantity).IsRequired();
            builder.Property(p => p.ProductPhotoPath).IsRequired();
            builder.Property(p => p.Color).HasMaxLength(50);
            builder.Property(p => p.IsProductOfTheMonth).HasDefaultValue(false);
            builder.Property(p => p.IsProductOfTheMonth).IsRequired();



        }
    }
}
