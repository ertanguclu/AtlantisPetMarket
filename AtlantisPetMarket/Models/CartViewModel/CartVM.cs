using AtlantisPetMarket.Models.CartItemVM;
using System;
using System.Collections.Generic;

namespace AtlantisPetMarket.Models.CartViewModel
{
    public class CartVM
    {
        public int Id { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now; 
        public int? UserId { get; set; } 
        public IEnumerable<CartItemViewModel> CartItems { get; set; } = new List<CartItemViewModel>();
    }
}
