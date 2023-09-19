using System.ComponentModel.DataAnnotations;

namespace SocialO.WebApi.Models.UserModels
{
    public class UserRegister
    {
        [Required(AllowEmptyStrings = false)]
        [RegularExpression(".*[a-zA]+.*", ErrorMessage = "Lutfen harf giriniz")]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email bilgilerinizi kontrol ediniz")]
        public string Email { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = " Sifre girilmesi zorunludur")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = " Sifrenizi tekrar giriniz")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = " Sifrenizi hatali girdiniz")]
        public string Repassword { get; set; }
    }
}