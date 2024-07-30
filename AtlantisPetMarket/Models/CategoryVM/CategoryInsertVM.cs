namespace AtlantisPetMarket.Models.CategoryVM
{
    public class CategoryInsertVM
    {
        public string CategoryName { get; set; }
        public IFormFile CategoryPhotoPath { get; set; }
        public int ParentCategoryId { get; set; }
    }
}
