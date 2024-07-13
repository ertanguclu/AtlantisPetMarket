using EntityLayer.Concrete;
using EntityLayer.Config.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Config.Concrete
{
    public class KategoriConfig : BaseConfig<Kategori>
    {
        public override void Configure(EntityTypeBuilder<Kategori> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.KategoriAdi).HasMaxLength(50);

            builder.HasIndex(p => p.KategoriAdi).IsUnique();


        }
    }
}
