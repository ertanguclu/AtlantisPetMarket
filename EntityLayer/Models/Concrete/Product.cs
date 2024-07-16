using EntityLayer.Concrete;
using EntityLayer.Models.Abstract;

namespace EntityLayer.Models.Concrete
{
    public class Product : BaseEntity
    {
        public string Brand { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ProductCode { get; set; }
        public int StockQuantity { get; set; }

        public string ProductPhotoPath { get; set; }  
        public int CategoryId { get; set; } 

        public Category Category { get; set; }
        public int ParentCategoryId { get; set; }

        public ParentCategory ParentCategory { get; set; }

        //public Photo Photo { get; set; }
    }
}
