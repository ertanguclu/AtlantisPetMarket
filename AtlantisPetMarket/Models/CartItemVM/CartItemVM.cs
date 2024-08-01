namespace AtlantisPetMarket.Models.CartItemVM
{
    public class CartItemVM
    {
        public int? Id { get; set; } // Güncelleme veya Silme işlemleri için gerekli.
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int CartId { get; set; }

     
    }

}
