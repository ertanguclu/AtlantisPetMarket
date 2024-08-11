using EntityLayer.Models.Concrete;

namespace BusinessLayer.Models.CartItemVM
{
    public class CartItemViewModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int CartId { get; set; }
        public  decimal Price { get; set; }
        public Cart Cart { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
