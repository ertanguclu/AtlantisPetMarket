using EntityLayer.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models.Concrete
{
    public class Cart : BaseEntity
    {
        public DateTime CreateDateTime { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

        // Sepet ile ilişkili siparişler
        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
