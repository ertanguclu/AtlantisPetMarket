using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityLayer.Config.Concrete
{
    public class SocialMediaConfig : IEntityTypeConfiguration<SocialMedia>
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            // Tablo adı
            builder.ToTable("SocialMedia");

            // Birincil anahtar
            builder.HasKey(a => a.Id);

            

            // Kolon konfigürasyonları
            builder.Property(sm => sm.Name)
                .IsRequired()   // Zorunlu kolon
                .HasMaxLength(100); // Maksimum uzunluk

            builder.Property(sm => sm.Url)
                .IsRequired()   // Zorunlu kolon
                .HasMaxLength(200); // Maksimum uzunluk

            builder.Property(sm => sm.Icon)
                .IsRequired()   // Zorunlu kolon
                .HasMaxLength(100); // Maksimum uzunluk
        }
    }
}
