using EntityLayer.Concrete;
using EntityLayer.Models.Abstract;

namespace EntityLayer.Models.Concrete
{
    public class Kafes : BaseEntity
    {
        public string KafesAdi { get; set; }
        public string Aciklama { get; set; }
        public decimal Fiyat { get; set; }
        public byte[] Resim { get; set; }

        public ICollection<Kategori> Kategoriler { get; set; }
    }
}
