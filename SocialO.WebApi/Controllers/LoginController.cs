using Microsoft.AspNetCore.Mvc;
using SocialO.WebApi.Models.UserModels.Login;
using SocialO.WebApi.Models.UserModels.Register;
using SocialO.WebApi.Services;

namespace SocialO.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly AuthService authService;

    public LoginController(AuthService authService)
    {
        this.authService = authService;
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<bool>> SignUp([FromBody] UserRegister userRegister)
    {
        var result = await authService.SignUp(userRegister);
        return result;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<bool>> Available(string input)
    {
        var result = await authService.Available(input);
        return result;
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<UserLoginResponse>> SignIn([FromBody] UserLoginRequest request)
    {
        var response = await authService.SignIn(request);

        if (response == null) return BadRequest(new { message = "Username or password is wrong!" });

        return response;
    }

    [HttpPost("{refreshToken}")]
    public async Task<ActionResult<UserLoginResponse>> RefreshTokenLogin(string refreshToken)
    {
        var response = await authService.RefreshTokenLogin(refreshToken);

        if (response == null) return Unauthorized(new { message = "Invalid token" });

        return response;
    }
}