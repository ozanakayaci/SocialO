using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialO.BL.Abstract;
using SocialO.BL.Concrete;
using SocialO.DAL.DBContexts;
using SocialO.Entities.Concrete;
using SocialO.WebApi.Models.UserModels.Login;
using SocialO.WebApi.Models.UserModels.Register;
using SocialO.WebApi.Services;
using SocialO.WebApi.Services.Interfaces;

namespace SocialO.WebApi.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly IUserManager userManager;
		private readonly IConfiguration configuration;
		private readonly SqlDBContext context;
		readonly IAuthService authService;

		public LoginController(IConfiguration configuration, IAuthService authService)
		{
			this.configuration = configuration;
			this.authService = authService;
			userManager = new UserManager();
			context = new SqlDBContext();
		}


		//Kullanıcı kayıt
		[HttpPost("[action]")]
		public async Task<bool> SignUp([FromForm] UserRegister userRegister)
		{

			PasswordHashHelper.CreatePasswordHash(userRegister.Password, out var passwordHash, out var passwordSalt);

			User user = new User
			{
				Username = userRegister.Username.ToLower(),
				Email = userRegister.Email.ToLower(),
				PasswordSalt = passwordSalt,
				PasswordHash = passwordHash,

			};

			int result = await userManager.InsertAsync(user);

			return result > 0 ? true : false;

		}

		//Kullanıcı giriş
		[HttpPost("[action]")]
		public async Task<ActionResult<UserLoginResponse>> SignIn([FromBody] UserLoginRequest request)
		{

			var result = await authService.LoginUserAsync(request);

			return result;

		}


		[HttpPost("[action]")]
		public async Task<ActionResult<UserLoginResponse>> RefreshTokenLogin([FromForm] string refreshToken)
		{
			User user = await context.Users.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);
			if (user != null && user?.RefreshTokenEndDate > DateTime.Now)
			{
				var result = await authService.RefreshTokenLoginAsync(user);
				return result;
			}
			throw new ArgumentNullException(nameof(refreshToken));
		}


	}
}
