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
    public class UrunConfig : BaseConfig<Urun>
    {
        public override void Configure(EntityTypeBuilder<Urun> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.UrunAdi).HasMaxLength(50);
            builder.Property(p => p.Aciklama).HasMaxLength(150);
            builder.Property(k => k.Fiyat).HasPrecision(18, 2);

            builder.Property(u => u.UrunAdi).IsRequired();
            builder.Property(u => u.Marka).IsRequired();
            builder.Property(u => u.Fiyat).IsRequired();


        }
    }
}
