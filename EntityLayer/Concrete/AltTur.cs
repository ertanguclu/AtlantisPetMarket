using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class AltTur : BaseEntity
    {
        public string Name { get; set; }
        public int AltTurID { get; set; }
        public AltTur AltTurler { get; set; }
    }
}
