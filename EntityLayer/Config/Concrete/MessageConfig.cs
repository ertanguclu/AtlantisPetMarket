using EntityLayer.Config.Abstract;
using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityLayer.Config.Concrete
{
    public class MessageConfig : BaseConfig<Message>
    {
        public override void Configure(EntityTypeBuilder<Message> builder)
        {
            base.Configure(builder);
            builder.Property(m => m.Sender).IsRequired();
            builder.Property(m => m.Receiver).IsRequired();
            builder.Property(m => m.SenderName).IsRequired();
            builder.Property(m => m.ReceiverName).IsRequired();
            builder.Property(m => m.Subject).IsRequired().HasMaxLength(20);
            builder.Property(m => m.MessageContent).IsRequired().HasMaxLength(500);

        }
    }
}
