using EntityLayer.Models.Abstract;
using EntityLayer.Models.Concrete;

namespace EntityLayer.Concrete
{
    public class Kategori : BaseEntity
    {
        public string KategoriAdi { get; set; }

        public string Aciklama { get; set; }

        public byte[] Resim { get; set; }
        public ICollection<UstKategori>? AltTurler { get; set; }
        public ICollection<Urun> Urunler { get; set; }


        public int? UstKategoriId { get; set; }
        public List<Stok> Stoklar { get; set; }

    }
}
