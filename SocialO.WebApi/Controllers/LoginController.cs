﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SocialO.BL.Abstract;
using SocialO.BL.Concrete;
using SocialO.DAL.DBContexts;
using SocialO.Entities.Concrete;
using SocialO.WebApi.Models.UserModels.Login;
using SocialO.WebApi.Models.UserModels.Register;
using SocialO.WebApi.Services;

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
            PasswordHashHelper.CreatePasswordHash(
                userRegister.Password,
                out var passwordHash,
                out var passwordSalt
            );

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
        public async Task<ActionResult<UserLoginResponse>> SignIn(
            [FromBody] UserLoginRequest request
        )
        {
            UserLoginResponse response = new();

            User user = await userManager.GetBy(
                p =>
                    (p.Username == request.Username.ToLower())
                    || (p.Email == request.Username.ToLower())
            );

            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (
                user != null
                && PasswordHashHelper.VerifyPasswordHash(
                    request.Password,
                    user.PasswordHash,
                    user.PasswordSalt
                )
            )
            {
                GenerateTokenResponse tokenInstance = new GenerateTokenResponse();

                SymmetricSecurityKey securityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"])
                );

                SigningCredentials signingCredentials = new SigningCredentials(
                    securityKey,
                    SecurityAlgorithms.HmacSha256
                );

                tokenInstance.TokenExpireDate = DateTime.Now.AddMinutes(5);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.UserType.ToString())
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

                byte[] number = new byte[32];
                RandomNumberGenerator random = RandomNumberGenerator.Create();
                random.GetBytes(number);

                tokenInstance.RefreshToken = Convert.ToBase64String(number);

                var generatedTokenInformation = tokenInstance;

                response.AuthenticateResult = true;
                response.AuthToken = generatedTokenInformation.Token;
                response.AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate;
                response.RefreshToken = generatedTokenInformation.RefreshToken;

                user.RefreshToken = generatedTokenInformation.RefreshToken;
                user.RefreshTokenEndDate = generatedTokenInformation.TokenExpireDate.AddHours(5);
                await userManager.UpdateAsync(user);
            }

            var result = response;

            return result;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<UserLoginResponse>> RefreshTokenLogin([FromForm] string refreshToken)
        {
            User user = await context.Users.FirstOrDefaultAsync(
                x => x.RefreshToken == refreshToken
            );
            if (user != null && user?.RefreshTokenEndDate > DateTime.Now)
            {
                UserLoginResponse response = new();

                GenerateTokenResponse tokenInstance = new GenerateTokenResponse();

                SymmetricSecurityKey securityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"])
                );

                SigningCredentials signingCredentials = new SigningCredentials(
                    securityKey,
                    SecurityAlgorithms.HmacSha256
                );

                tokenInstance.TokenExpireDate = DateTime.Now.AddMinutes(5);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.UserType.ToString())
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

                byte[] number = new byte[32];
                RandomNumberGenerator random = RandomNumberGenerator.Create();
                random.GetBytes(number);

                tokenInstance.RefreshToken = Convert.ToBase64String(number);

                var generatedTokenInformation = tokenInstance;

                response.AuthenticateResult = true;
                response.AuthToken = generatedTokenInformation.Token;
                response.AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate;
                response.RefreshToken = generatedTokenInformation.RefreshToken;

                user.RefreshToken = generatedTokenInformation.RefreshToken;
                user.RefreshTokenEndDate = generatedTokenInformation.TokenExpireDate.AddHours(5);
                await userManager.UpdateAsync(user);

                return response;
            }

            return null;
        }
    }
}
