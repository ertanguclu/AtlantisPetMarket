namespace AtlantisPetMarket.Models.CategortVm
{
    public class CategoryUpdateVM
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public IFormFile CategoryPhotoPath { get; set; }
        public int ParentCategoryId { get; set; }
    }
}

