using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class HayvanMama : BaseEntity
    {
        public int HayvanId { get; set; }
        public int MamaId { get; set; }
        public Hayvan Hayvanlar { get; set; }
        public Mama Mamalar { get; set; }
    }
}
