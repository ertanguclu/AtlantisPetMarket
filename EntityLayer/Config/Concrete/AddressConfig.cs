using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EntityLayer.Config.Abstract;

public class CategoryConfig : BaseConfig<Category>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Street).IsRequired().HasMaxLength(255);
        builder.Property(a => a.City).IsRequired().HasMaxLength(100);
        builder.Property(a => a.State).HasMaxLength(100);
        builder.Property(a => a.PostalCode).IsRequired().HasMaxLength(20);
        builder.Property(a => a.Country).IsRequired().HasMaxLength(100);

        builder.HasOne(a => a.User)
               .WithMany(u => u.Addresses)
               .HasForeignKey(a => a.UserId);
    }
}
