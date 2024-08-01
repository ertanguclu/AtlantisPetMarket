using EntityLayer.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models.Concrete
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public decimal OrderAmount { get; set; }
        public enum OrderStatus
        {
            Pending = 1,
            Shipped,
            Delivered,
            Canceled
        }
        public int UserId { get; set; }
        public User User { get; set; }
        public int? CartId { get; set; } // Nullable olmalı çünkü sipariş her zaman bir sepetle ilişkili olmayabilir
        public Cart Cart { get; set; }

    }
}
