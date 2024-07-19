using System.ComponentModel.DataAnnotations;

namespace AtlantisPetMarket.Areas.Writer.Models
{
    public class UserLoginViewModel
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı Adınızı Giriniz...!")]
        public string Username { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifreyi Giriniz...!")]
        public string Password { get; set; }
    }
}
