namespace AtlantisPetMarket.Models.CategoryVM
{
    public class CategoryUpdateVM
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CurrentPhotoPath { get; set; }
        public IFormFile CategoryPhotoPath { get; set; }
        public int ParentCategoryId { get; set; }
    }
}

