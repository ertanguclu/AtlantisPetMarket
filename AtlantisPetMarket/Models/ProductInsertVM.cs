namespace AtlantisPetMarket.Models
{
    public class ProductInsertVM
    {
        public string Brand { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ProductCode { get; set; }
        public int StockQuantity { get; set; }
        public string ProductPhotoPath { get; set; }

        public string? Color { get; set; }
    }
}
