using Microsoft.IdentityModel.Tokens;
using SocialO.Entities.Concrete;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace SocialO.WebApi.Models;

public class TokenManager
{
    private readonly IConfiguration _configuration;

    public TokenManager(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<Token> CreateAccessToken(User user)
    {
        var tokenInstance = new Token();

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        tokenInstance.Expiration = DateTime.Now.AddMinutes(5);

        var securityToken = new JwtSecurityToken(
            _configuration["Token:Issuer"],
            _configuration["Token:Audience"],
            expires: tokenInstance.Expiration,
            notBefore: DateTime.Now,
            signingCredentials: signingCredentials
        );

        var tokenHandler = new JwtSecurityTokenHandler();

        tokenInstance.AccessToken = tokenHandler.WriteToken(securityToken);

        tokenInstance.RefreshToken = CreateRefreshToken();
        return tokenInstance;
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