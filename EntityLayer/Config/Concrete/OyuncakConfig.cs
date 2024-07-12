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
    public class OyuncakConfig : BaseConfig<Oyuncak>
    {
        public override void Configure(EntityTypeBuilder<Oyuncak> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.OyuncakAdi).HasMaxLength(50);
            builder.Property(p => p.Aciklama).HasMaxLength(150);

            builder.Property(k => k.Fiyat).HasPrecision(18, 2);


        }
    }
}
