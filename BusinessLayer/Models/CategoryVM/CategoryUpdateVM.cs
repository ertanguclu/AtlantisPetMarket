namespace BusinessLayer.Models.CategoryVM
{
    public class CategoryUpdateVM
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int ParentCategoryId { get; set; }
    }
}

