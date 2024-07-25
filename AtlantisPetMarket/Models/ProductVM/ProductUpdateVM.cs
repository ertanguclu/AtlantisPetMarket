using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AtlantisPetMarket.Models.ProductVM
{
    public class ProductUpdateVM
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ProductCode { get; set; }
        public int StockQuantity { get; set; }
        public string ProductPhotoPath { get; set; }

        public int CategoryId { get; set; }
        public Category category { get; set; }
        public List<SelectListItem> Categories { get; set; }
        //public int ParentCategoryId { get; set; }
        public List<SelectListItem> ParentCategories { get; set; }

        public string? Color { get; set; }
    }
}
