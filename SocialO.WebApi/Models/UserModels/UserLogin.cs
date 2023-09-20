using System.ComponentModel.DataAnnotations;

namespace SocialO.WebApi.Models.UserModels

{
    public class UserLogin
    {
	    [Required(AllowEmptyStrings = false, ErrorMessage = "Bu alan boş bırakılamaz")]
		public string LoginString { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Bu alan boş bırakılamaz")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
    }
}