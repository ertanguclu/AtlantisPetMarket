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
    public class ParentCategoryConfig:  BaseConfig<ParentCategory>
    {

        public override void Configure(EntityTypeBuilder<ParentCategory> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.ParentCategoryName).HasMaxLength(20);

            builder.HasData(
                new ParentCategory {Id = 1, ParentCategoryName = "Kedi", CreateDate = DateTime.Now},
                new ParentCategory { Id = 2, ParentCategoryName = "Köpek", CreateDate = DateTime.Now},
                new ParentCategory { Id = 3, ParentCategoryName = "Kuş", CreateDate = DateTime.Now},
                new ParentCategory { Id = 4,  ParentCategoryName = "Balık", CreateDate = DateTime.Now},
                new ParentCategory { Id = 5, ParentCategoryName = "Kemirgen", CreateDate = DateTime.Now}
                );

        }
    }
}
