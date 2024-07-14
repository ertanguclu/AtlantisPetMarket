using EntityLayer.Models.Abstract;
using EntityLayer.Models.Concrete;

namespace EntityLayer.Concrete
{
    public class Kategori : BaseEntity
    {
        public string KategoriAdi { get; set; }

        //public string Aciklama { get; set; }

        public string KategoriFotoDosyaYolu { get; set; }

        public int UstKategoriId { get; set; }

        public UstKategori UstKategori { get; set; }
        public ICollection<Urun> Urunler { get; set; }


    }
}
