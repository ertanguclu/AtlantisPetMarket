using EntityLayer.Models.Abstract;

namespace EntityLayer.Models.Concrete
{
    public class Contact : BaseEntity
    {
        public string SellerName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Message { get; set; }
    }
}
