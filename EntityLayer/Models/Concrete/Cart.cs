using EntityLayer.Models.Abstract;
using EntityLayer.Models.Concrete;

public class Cart : BaseEntity
{
    public DateTime CreateDateTime { get; set; }
    public int? UserId { get; set; }
    public User? User { get; set; } 
    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
