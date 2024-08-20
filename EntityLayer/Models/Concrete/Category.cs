using EntityLayer.Models.Abstract;

namespace EntityLayer.Models.Concrete
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public int ParentCategoryId { get; set; }
        public ParentCategory ParentCategory { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
