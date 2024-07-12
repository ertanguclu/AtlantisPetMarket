using EntityLayer.Models.Abstract;

namespace EntityLayer.Concrete
{
    public class AltTur : BaseEntity
    {
        public string AltTurAdi { get; set; }  // Alt tür adı
        public int KategoriId { get; set; }  // Hangi kategoriye ait olduğu

        public Kategori Kategori { get; set; }  // Alt türün ait olduğu kategori
    }
}
