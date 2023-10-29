namespace SocialO.WebApi.Models.UserModels.Login
{
    public class GenerateTokenResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime TokenExpireDate { get; set; }
    }
}
