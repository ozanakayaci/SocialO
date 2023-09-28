using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SocialO.WebApi.Models;
using SocialO.Entities.Concrete;
using SocialO.WebApi.Services.Interfaces;
using System.Security.Cryptography;

namespace SocialO.WebApi.Services
{
    public class TokenService:ITokenService
	{
		readonly IConfiguration configuration;

		public TokenService(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public async Task<GenerateTokenResponse> GenerateToken(User user)
		{
			GenerateTokenResponse tokenInstance = new GenerateTokenResponse();

			SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]));

			SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			tokenInstance.TokenExpireDate = DateTime.Now.AddMinutes(5);


			var claims = new List<Claim> {
					new Claim(ClaimTypes.Name, user.Username ),
					new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
					new Claim(ClaimTypes.Role,user.UserType.ToString())
					};

			JwtSecurityToken jwt = new JwtSecurityToken(
					issuer: configuration["Token:Issuer"],
					audience: configuration["Token:Audience"],
					claims: claims,
					notBefore: DateTime.Now,
					expires: tokenInstance.TokenExpireDate,
					signingCredentials: signingCredentials
				);

			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

			tokenInstance.Token = tokenHandler.WriteToken(jwt);

			tokenInstance.RefreshToken = CreateRefreshToken();


			return await Task.FromResult(tokenInstance);
		}

		public string CreateRefreshToken()
		{
			byte[] number = new byte[32];
			using (RandomNumberGenerator random = RandomNumberGenerator.Create())
			{
				random.GetBytes(number);
				return Convert.ToBase64String(number);
			}
		}
	}
}
