using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class Mama : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public byte[] Resim { get; set; }
        public ICollection<HayvanMama> HayvanMamalari { get; set; }
    }
}
