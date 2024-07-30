using EntityLayer.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models.Concrete
{
    public class Review : BaseEntity
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
