using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class KategoriUrun : BaseEntity
    {
        public int HayvanTurleriId { get; set; }
        public int? AltTurId { get; set; }
        public int UrunId { get; set; }

        public HayvanTurleri HayvanTurleri { get; set; }
        public AltTur AltTurler { get; set; }
        public Urun Urunler { get; set; }
    }
}
