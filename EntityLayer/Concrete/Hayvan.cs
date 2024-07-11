using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class Hayvan : BaseEntity
    {
        public string Name { get; set; }
        public byte[] Resim { get; set; }
        public int AltTurId { get; set; }
        public AltTur? AltTurler { get; set; }
        public ICollection<HayvanUrun> HayvanUrunleri { get; set; }
    }
}
