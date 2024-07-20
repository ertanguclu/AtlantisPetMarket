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

            builder.Property(p => p.CategoryName).HasMaxLength(50);

            builder.HasIndex(p => p.CategoryName).IsUnique();


        }
    }
}
