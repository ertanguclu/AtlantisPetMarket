using AtlantisPetMarket.Models.CartItemVM;
using EntityLayer.Models.Concrete;
using System;
using System.Collections.Generic;

namespace AtlantisPetMarket.Models.CartViewModel
{
    public class CartVM
    {
        public int Id { get; set; } 
        public DateTime CreateDateTime { get; set; }
        public int UserId { get; set; }
        public IEnumerable<CartItemViewModel> CartItems { get; set; } = new List<CartItemViewModel>();
       
        public Cart Cart { get; set; }
    }
}
