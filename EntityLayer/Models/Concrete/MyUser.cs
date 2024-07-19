using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Models.Concrete
{
    public class MyUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? TcNo { get; set; }
        public bool? Cinsiyet { get; set; }

        public DateTime? DogumTarihi { get; set; }

        [NotMapped] // Burasi Database'e yansimayacaktir
        public int? Yas { get; set; }

        public string? ImagePath { get; set; }
        public string? About { get; set; }

        public MyUser()
        {
            if (DogumTarihi.HasValue)
                Yas = DateTime.Now.Year - DogumTarihi.Value.Year;
        }
    }
}
