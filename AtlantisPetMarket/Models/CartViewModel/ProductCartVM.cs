using AtlantisPetMarket.Models.CartItemVM;
using EntityLayer.Models.Concrete;

namespace AtlantisPetMarket.Models.CartViewModel
{
    public class ProductCartVM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User MyProperty { get; set; }

        public string Brand { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ProductCode { get; set; }
        
        public string ProductPhotoPath { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public IEnumerable<CartItemViewModel> CartItems { get; set; }


    }
}
