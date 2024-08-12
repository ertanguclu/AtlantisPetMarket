namespace AtlantisPetMarket.Models.ProductVM
{
    public class ProductInsertVM
    {
        public string Brand { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ProductCode { get; set; }
        public int StockQuantity { get; set; }
        public IFormFile ProductPhotoPath { get; set; }

        public string? Color { get; set; }
        public int CategoryId { get; set; }

        public int ParentCategoryId { get; set; }
    }
}
