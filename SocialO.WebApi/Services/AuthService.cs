using SocialO.BL.Abstract;
using SocialO.BL.Concrete;
using SocialO.Entities.Concrete;
using SocialO.WebApi.Services.Interfaces;
using SocialO.WebApi.Models.UserModels.Login;

namespace SocialO.WebApi.Services;

public class AuthService : IAuthService
{
	readonly ITokenService tokenService;
	private readonly IUserManager userManager;
	
	public AuthService(ITokenService tokenService)
	{
		this.tokenService = tokenService;
		userManager = new UserManager();
	}
		

	public async Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request)
	{
		UserLoginResponse response = new();

		User user = await userManager.GetBy(p => (p.Username == request.Username.ToLower()) || (p.Email == request.Username.ToLower()));

		if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
		{
			throw new ArgumentNullException(nameof(request));
		}

		if (user != null && PasswordHashHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
		{
			var generatedTokenInformation = await tokenService.GenerateToken( user);



			response.AuthenticateResult = true;
			response.AuthToken = generatedTokenInformation.Token;
			response.AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate;
			response.RefreshToken = generatedTokenInformation.RefreshToken;
			
			user.RefreshToken = generatedTokenInformation.RefreshToken;
			user.RefreshTokenEndDate = generatedTokenInformation.TokenExpireDate.AddHours(5);
			await userManager.UpdateAsync(user);
		}



		return response;
	}

	public async Task<UserLoginResponse> RefreshTokenLoginAsync(User user)
	{
			UserLoginResponse response = new();
		
			var generatedTokenInformation = await tokenService.GenerateToken( user);

			response.AuthenticateResult = true;
			response.AuthToken = generatedTokenInformation.Token;
			response.AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate;
			response.RefreshToken = generatedTokenInformation.RefreshToken;
			
			user.RefreshToken = generatedTokenInformation.RefreshToken;
			user.RefreshTokenEndDate = generatedTokenInformation.TokenExpireDate.AddHours(5);
			await userManager.UpdateAsync(user);
		



		return response;
		
		
		
	}
}	