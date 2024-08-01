using EntityLayer.Models.Abstract;

namespace EntityLayer.Models.Concrete
{
    public class SocialMedia : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
