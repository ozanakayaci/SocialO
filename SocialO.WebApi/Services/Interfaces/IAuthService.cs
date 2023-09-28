using SocialO.Entities.Concrete;
using SocialO.WebApi.Models.UserModels.Login;

namespace SocialO.WebApi.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request);
        public Task<UserLoginResponse> RefreshTokenLoginAsync(User user);
    }
}
