using EntityLayer.Models.Concrete;

namespace BusinessLayer.Models.CartItemVM
{
    public class CartItemViewModel
    {
        public int? Id { get; set; } // Güncelleme veya Silme işlemleri için gerekli.
        public int Quantity { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }

}
