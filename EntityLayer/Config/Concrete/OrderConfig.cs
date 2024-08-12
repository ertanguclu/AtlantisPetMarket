using EntityLayer.Config.Abstract;
using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityLayer.Config.Concrete
{
    public class OrderConfig : BaseConfig<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);
            builder.Property(o => o.UserId).IsRequired();
            builder.Property(o => o.OrderDate).IsRequired();
            builder.Property(o => o.OrderAmount).HasColumnType("decimal(18,2)");
            ;
        }
    }
}
