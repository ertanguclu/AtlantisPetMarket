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
    public class MamaConfig : BaseConfig<Mama>
    {
        public override void Configure(EntityTypeBuilder<Mama> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.MamaAdi).HasMaxLength(50);
            builder.Property(p => p.Aciklama).HasMaxLength(150);

            builder.Property(k => k.Fiyat).HasPrecision(18, 2);


        }
    }
}
