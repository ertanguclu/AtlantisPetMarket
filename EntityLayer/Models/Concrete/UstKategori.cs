using EntityLayer.Models.Abstract;

namespace EntityLayer.Concrete
{
    public class UstKategori : BaseEntity
    {
        public string UstKategoriAdi { get; set; }  // Hangi Hayvana Ait oldugu
        

        public ICollection<Kategori> Kategoriler { get; set; }  // Alt türün ait olduğu kategori
    }
}
