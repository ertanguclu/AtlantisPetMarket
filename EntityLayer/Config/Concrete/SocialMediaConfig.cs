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

            builder.Property(sm => sm.Name)
                .IsRequired()   
                .HasMaxLength(20); 

            builder.Property(sm => sm.Url)
                .IsRequired()   
                .HasMaxLength(200); 

            builder.Property(sm => sm.Icon)
                .IsRequired()  
                .HasMaxLength(100); 
    }
}
