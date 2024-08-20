using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusinessLayer.Models.ProductVM
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
        public bool IsProductOfTheMonth { get; set; }
        public IFormFile ProductPhotoUpdate { get; set; }
        public string ProductPhotoPath { get; set; }

        public int CategoryId { get; set; }
        public Category category { get; set; }
        public int ParentCategoryId { get; set; }
        public ParentCategory ParentCategory { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> ParentCategories { get; set; }

        public string? Color { get; set; }
    }
}
