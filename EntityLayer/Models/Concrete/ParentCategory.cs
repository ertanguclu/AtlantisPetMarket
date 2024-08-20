using EntityLayer.Models.Abstract;

namespace EntityLayer.Models.Concrete
{
    public class ParentCategory : BaseEntity
    {
        public string ParentCategoryName { get; set; }  

        public ICollection<Category> Categories { get; set; }  
    }
}
