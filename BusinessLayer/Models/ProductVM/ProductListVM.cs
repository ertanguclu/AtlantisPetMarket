﻿using EntityLayer.Models.Concrete;

namespace BusinessLayer.Models.ProductVM
{
    public class ProductListVM
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ProductCode { get; set; }
        public int StockQuantity { get; set; }
        public string ProductPhotoPath { get; set; }
        public bool IsProductOfTheMonth { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int ParentCategoryId { get; set; }
        public ParentCategory ParentCategory { get; set; }

        public string? Color { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}