using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class HayvanUrun : BaseEntity
    {
        public int HayvanId { get; set; }
        public int UrunId { get; set; }

        public Hayvan Hayvanlar { get; set; }
        public Urun Urunler { get; set; }
    }
}
