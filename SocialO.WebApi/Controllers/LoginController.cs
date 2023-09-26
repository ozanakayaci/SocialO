﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialO.BL.Abstract;
using SocialO.BL.Concrete;
using SocialO.DAL.DBContexts;
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
		private readonly IUserManager userManager;
		private readonly IConfiguration configuration;
		private readonly SqlDBContext context;

		public LoginController(IConfiguration configuration)
		{
			this.configuration = configuration;
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
		public async Task<Token> SignIn(UserLogin userLogin)
		{

			

			User user = await userManager.GetBy(p => (p.Username == userLogin.LoginString.ToLower()) || (p.Email == userLogin.LoginString.ToLower()));

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
				await userManager.UpdateAsync(user);
				return token;
			}

			return null;
		}


		[HttpGet("[action]")]
		public async Task<Token> RefreshTokenLogin( string refreshToken)
		{
			User user = await context.Users.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);
			if (user != null && user?.RefreshTokenEndDate > DateTime.Now)
			{
				TokenManager tokenHandler = new TokenManager(configuration);
				Token token = await tokenHandler.CreateAccessToken(user);

				user.RefreshToken = token.RefreshToken;
				user.RefreshTokenEndDate = token.Expiration.AddMinutes(5);
				await context.SaveChangesAsync();

				return token;
			}
			return null;
		}


	}
}
