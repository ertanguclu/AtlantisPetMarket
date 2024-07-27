namespace AtlantisPetMarket.Models.CategoryVM
{
    public class CategoryInsertVM
    {
        public string CategoryName { get; set; }
        public string CategoryPhotoPath { get; set; }
        public int ParentCategoryId { get; set; }
    }
}
