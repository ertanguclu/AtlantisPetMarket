using EntityLayer.Concrete;
using EntityLayer.Config.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Config.Concrete
{
    public class AltturConfig : BaseConfig<UstKategori>
    {
        public override void Configure(EntityTypeBuilder<UstKategori> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.AltTurAdi).HasMaxLength(50);

            builder.HasIndex(p => p.AltTurAdi).IsUnique();


        }
    }
}
