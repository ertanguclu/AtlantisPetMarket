using EntityLayer.Concrete;
using EntityLayer.Models.Abstract;

namespace EntityLayer.Models.Concrete
{
    public class Oyuncak : BaseEntity
    {
        public string OyuncakAdi { get; set; }
        public string Aciklama { get; set; }
        public decimal Fiyat { get; set; }
        public byte[] Resim { get; set; }
        public ICollection<Kategori> Kategoriler { get; set; }
    }
}
