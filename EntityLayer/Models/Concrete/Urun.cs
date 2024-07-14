using EntityLayer.Concrete;
using EntityLayer.Models.Abstract;

namespace EntityLayer.Models.Concrete
{

    public class Urun : BaseEntity
    {
        public string Marka { get; set; }
        public string  UrunAdi { get; set; }
        public string Aciklama { get; set; }
        public decimal Fiyat { get; set; }
        public string UrunKodu { get; set; }
        public int StokAdedi { get; set; }
        

        public string UrunfotoDosyaYolu { get; set; }  //burası çalışılmalı
        public int KategoriId { get; set; } // ürünün hangi kategoride oldugu ornek :Yas mama

        public Kategori Kategori { get; set; }
        public int UstKategoriId { get; set; } // ürünün hangi hayvana ait oldugu

        public UstKategori UstKategori { get; set; }

        //public Fotograf Fotograf { get; set; } // burası çalışılmalı
    }
}
