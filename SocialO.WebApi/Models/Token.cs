using SocialO.Entities.Concrete;

namespace SocialO.WebApi.Models
{
    public class Token
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; internal set; }

        public User User { get; set; }
    }
}