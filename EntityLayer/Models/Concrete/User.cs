using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Models.Concrete
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? TcNo { get; set; }
        public bool? Gender { get; set; }

        public DateTime? BirthDate { get; set; }

        [NotMapped] // Burasi Database'e yansimayacaktir
        public int? Yas { get; set; }

        public string? ImagePath { get; set; }
        public string? About { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Review> Reviews { get; set; }

        public User()
        {
            if (BirthDate.HasValue)
                Yas = DateTime.Now.Year - BirthDate.Value.Year;
        }
    }
}
