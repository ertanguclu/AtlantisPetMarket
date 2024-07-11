using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class Kategori : BaseEntity
    {
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public ICollection<Urun> Urunler { get; set; }
    }
}
