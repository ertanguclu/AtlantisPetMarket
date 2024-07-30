using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Models.Concrete;
using EntityLayer.Config.Abstract;

namespace EntityLayer.Config.Concrete
{
    public class OrderConfig : BaseConfig<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.UserId).IsRequired();
            builder.Property(o => o.OrderDate).IsRequired();
            builder.Property(o => o.OrderAmount).HasColumnType("decimal(18,2)");
;
        }
    }
}
