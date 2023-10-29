using SocialO.Entities.Concrete;
using SocialO.WebApi.Models.UserModels.Login;

namespace SocialO.WebApi.Services.Interfaces;

public interface ITokenService
{
    public Task<GenerateTokenResponse> GenerateToken(User user);
}