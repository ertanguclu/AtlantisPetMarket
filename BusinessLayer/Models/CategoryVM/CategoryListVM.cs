using EntityLayer.Models.Concrete;

namespace BusinessLayer.Models.CategoryVM
{
    public class CategoryListVM
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int ParentCategoryId { get; set; }
        public ParentCategory ParentCategory { get; set; }
    }
}
