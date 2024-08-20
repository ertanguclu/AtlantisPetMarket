using EntityLayer.Config.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CartConfig : BaseConfig<Cart>
{
    public override void Configure(EntityTypeBuilder<Cart> builder)
    {
        base.Configure(builder);
        builder.Property(c => c.UserId).IsRequired(false); // Nullable UserId
        builder.Property(c => c.SessionId).IsRequired(); // Zorunlu SessionId
        builder.Property(c => c.CreateDateTime).IsRequired();
    }
}
