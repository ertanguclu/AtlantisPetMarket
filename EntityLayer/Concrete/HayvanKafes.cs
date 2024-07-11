using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class HayvanKafes : BaseEntity
    {
        public int HayvanId { get; set; }
        public int KafesId { get; set; }

        public Hayvan Hayvanlar { get; set; }
        public Kafes Kafesler { get; set; }
    }
}
