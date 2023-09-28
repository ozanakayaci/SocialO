namespace SocialO.WebApi.Models.UserModels.Login
{
	public class UserLoginResponse
	{
		public bool AuthenticateResult { get; set; }

	
		public string AuthToken { get; set; }

		public string RefreshToken {  get; set; }
		
		public DateTime AccessTokenExpireDate { get; set; }

	}
}
