using EntityLayer.Config.Abstract;
using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityLayer.Config.Concrete
{
    public class SocialMediaConfig : BaseConfig<SocialMedia>
    {
        public override void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            base.Configure(builder);

            // Kolon konfigürasyonları
            builder.Property(sm => sm.Name)
                .IsRequired()   // Zorunlu kolon
                .HasMaxLength(20); // Maksimum uzunluk

            builder.Property(sm => sm.Url)
                .IsRequired()   // Zorunlu kolon
                .HasMaxLength(200); // Maksimum uzunluk

            builder.Property(sm => sm.Icon)
                .IsRequired()   // Zorunlu kolon
                .HasMaxLength(100); // Maksimum uzunluk
        }
    }
}
