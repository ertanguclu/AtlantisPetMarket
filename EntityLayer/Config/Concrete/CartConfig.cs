using EntityLayer.Config.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CartConfig : BaseConfig<Cart>
{
    public override void Configure(EntityTypeBuilder<Cart> builder)
    {
        base.Configure(builder);
        builder.Property(c => c.UserId).IsRequired(false);
        builder.Property(c => c.CreateDateTime).IsRequired();
    }
}
