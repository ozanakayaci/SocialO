using Microsoft.IdentityModel.Tokens;
using SocialO.Entities.Concrete;
using SocialO.WebApi.Models.UserModels.Login;
using SocialO.WebApi.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SocialO.WebApi.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration configuration;

    public TokenService(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public async Task<GenerateTokenResponse> GenerateToken(User user)
    {
        var tokenInstance = new GenerateTokenResponse();

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]));

        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        tokenInstance.TokenExpireDate = DateTime.Now.AddMinutes(5);


        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Username),
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Role, user.UserType)
        };

        var jwt = new JwtSecurityToken(
            configuration["Token:Issuer"],
            configuration["Token:Audience"],
            claims,
            DateTime.Now,
            tokenInstance.TokenExpireDate,
            signingCredentials
        );

        var tokenHandler = new JwtSecurityTokenHandler();

        tokenInstance.Token = tokenHandler.WriteToken(jwt);

        tokenInstance.RefreshToken = CreateRefreshToken();


        return await Task.FromResult(tokenInstance);
    }

    public string CreateRefreshToken()
    {
        var number = new byte[32];
        using (var random = RandomNumberGenerator.Create())
        {
            random.GetBytes(number);
            return Convert.ToBase64String(number);
        }
    }
}