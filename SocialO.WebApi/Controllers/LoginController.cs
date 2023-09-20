using Microsoft.AspNetCore.Mvc;
using SocialO.BL.Abstract;
using SocialO.BL.Concrete;
using SocialO.Entities.Concrete;
using SocialO.WebApi.Extensions;
using SocialO.WebApi.Models;
using SocialO.WebApi.Models.UserModels;

namespace SocialO.WebApi.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly IUserManager context;
		private readonly IConfiguration configuration;

		public LoginController(IConfiguration configuration)
		{
			this.configuration = configuration;
			this.context = new UserManager();
		}

		[HttpPost("[action]")]
		public async Task<Token> Login(UserLogin userLogin)
		{

			

			User user = await context.GetBy(p => (p.Username == userLogin.LoginString.ToLower()) || (p.Email == userLogin.LoginString.ToLower()));

			if (user == null)
			{
				return null;
			}

			if (PasswordHashHelper.VerifyPasswordHash(userLogin.Password, user.PasswordHash, user.PasswordSalt))
			{				
				TokenManager tokenManager = new TokenManager(configuration);
				Token token = await tokenManager.CreateAccessToken(user);

				user.RefreshToken = token.RefreshToken;
				user.RefreshTokenEndDate = token.Expiration.AddMinutes(5);
				token.User = user;
				await context.UpdateAsync(user);
				return token;
			}

			return null;
		}

		
		[HttpGet("[action]")]
		public async Task<Token> RefreshTokenLogin([FromForm] string refreshToken)
		{
			User user = await context.GetBy(x => x.RefreshToken == refreshToken);
			if (user != null && user?.RefreshTokenEndDate > DateTime.Now)
			{
				TokenManager tokenHandler = new TokenManager(configuration);
				Token token = await tokenHandler.CreateAccessToken(user);

				user.RefreshToken = token.RefreshToken;
				user.RefreshTokenEndDate = token.Expiration.AddMinutes(5);
				await context.UpdateAsync(user);

				return token;
			}
			return null;
		}

		[HttpPost("[action]")]
		public async Task<bool> Create([FromForm] UserRegister userRegister)
		{

			PasswordHashHelper.CreatePasswordHash(userRegister.Password, out var passwordHash, out var passwordSalt);

			User user = new User
			{
				Username = userRegister.Username.ToLower(),
				Email = userRegister.Email.ToLower(),
				PasswordSalt = passwordSalt,
				PasswordHash = passwordHash,
				
			};
			
			int result = await context.InsertAsync(user);

			return result > 0 ? true : false;

		}

	}
}
