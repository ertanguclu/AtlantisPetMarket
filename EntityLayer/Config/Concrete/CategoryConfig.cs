using EntityLayer.Config.Abstract;
using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityLayer.Config.Concrete
{
    public class CategoryConfig : BaseConfig<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.CategoryName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.CategoryPhotoPath).IsRequired();
            builder.Property(p => p.ParentCategoryId).IsRequired();

            //category resim silinecek


        }
    }
}
