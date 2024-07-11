using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{

    public class HayvanTurleri : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<AltTur> AltTurs { get; set; }
    }
}
