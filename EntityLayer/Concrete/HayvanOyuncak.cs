using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class HayvanOyuncak : BaseEntity
    {
        public int HayvanId { get; set; }
        public int OyuncakId { get; set; }

        public Hayvan Hayvanlar { get; set; }
        public Oyuncak Oyuncaklar { get; set; }
    }
}
