using EntityLayer.Models.Abstract;
using EntityLayer.Models.Concrete;

namespace EntityLayer.Concrete
{
    public class Kategori : BaseEntity
    {
        public string KategoriAdi { get; set; }
        public byte[] Resim { get; set; }
        public ICollection<AltTur>? AltTurler { get; set; }
        public ICollection<Urun> Urunler { get; set; }
        public ICollection<Mama> Mamalar { get; set; }
        public ICollection<Kafes> Kafesler { get; set; }
    }
}
