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
    }
}
