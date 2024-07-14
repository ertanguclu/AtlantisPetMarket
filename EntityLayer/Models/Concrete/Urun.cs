using EntityLayer.Concrete;
using EntityLayer.Models.Abstract;

namespace EntityLayer.Models.Concrete
{

    public class Urun : BaseEntity
    {
        public string  UrunAdi { get; set; }
        public string Marka { get; set; }
        public string Aciklama { get; set; }
        public decimal Fiyat { get; set; }
        public string UrunKodu { get; set; }
        public string MalzemeKodu { get; set; }
        public int StokAdedi { get; set; }

        public byte[] Urunfoto { get; set; }

        public ICollection<Kategori> Kategoriler { get; set; }

        public Fotograf Fotograf { get; set; }
    }
}
