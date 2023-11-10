using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SocialO.BL.Abstract;
using SocialO.BL.Concrete;
using SocialO.Entities.Concrete;
using SocialO.WebApi.Models.UserModels.Login;
using SocialO.WebApi.Models.UserModels.Register;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SocialO.WebApi.Services
{
    public class AuthService
    {
        private readonly IUserManager _userManager;
        private readonly IFollowerRelationshipManager _followerRelationshipManager;
        private readonly IUserProfileManager _userProfileManager;
        private readonly IConfiguration configuration;

        public AuthService(IUserManager userManager,IFollowerRelationshipManager followerRelationshipManager,IUserProfileManager userProfileManager ,IConfiguration configuration)
        {
            _userManager = userManager;
            _followerRelationshipManager = followerRelationshipManager;
            _userProfileManager = userProfileManager;
            this.configuration = configuration;
        }

        public async Task<bool> SignUp(UserRegister userRegister)
        {
            // Kullanıcı adının veya e-postanın veritabanında mevcut olup olmadığını kontrol et
            bool usernameExist = await _userManager.GetBy(x => x.Username == userRegister.Username) != null;
            bool emailExist = await _userManager.GetBy(x => x.Email == userRegister.Email) != null;

            if (usernameExist)
            {
                return false; // Kullanıcı adı zaten alınmış
            }
            if (emailExist)
            {
                return false; // E-posta zaten alınmış
            }

            if (userRegister.Password != userRegister.Repassword)
            {
                return false; // Parolalar eşleşmiyor
            }

            // Parola hashleme işlemleri burada gerçekleştirilir
            PasswordHashHelper.CreatePasswordHash(userRegister.Password, out var passwordHash, out var passwordSalt);

            // Yeni kullanıcı oluştur
            User user = new User
            {
                Username = userRegister.Username.ToLower(),
                Email = userRegister.Email.ToLower(),
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
            };

            int result = await _userManager.InsertAsync(user);

            FollowerRelationship relationship = new FollowerRelationship
            {
                FollowerId = user.Id,
                UserId = user.Id
            };

            int result2 = await _followerRelationshipManager.InsertAsync(relationship);


            UserProfile profile = new UserProfile
            {
                FirstName = userRegister.Username.ToLower(),
                UserId = user.Id


            };
            int result3 = await _userProfileManager.InsertAsync(profile);


            return result > 0; // Kayıt başarılıysa true, aksi takdirde false döner
        }

        public async Task<bool> Available(string input)
        {
            // Kullanıcı adının veya e-postanın veritabanında mevcut olup olmadığını kontrol et
            bool usernameExist = await _userManager.GetBy(x => x.Username == input) != null;
            bool emailExist = await _userManager.GetBy(x => x.Email == input) != null;

            // Eğer kullanıcı adı veya e-posta mevcutsa, false döner; aksi takdirde true döner
            return !usernameExist && !emailExist;
        }

        public async Task<UserLoginResponse> SignIn(UserLoginRequest request)
        {
            User user = await _userManager.GetBy(p => (p.Username == request.Username.ToLower()) || (p.Email == request.Username.ToLower()));

            if (user == null || !PasswordHashHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return null; // Kullanıcı adı veya parola yanlış
            }

            return GenerateTokenResponse(user);
        }

        public async Task<UserLoginResponse> RefreshTokenLogin(string refreshToken)
        {
            // Refresh token ile oturum yenileme işlemleri burada gerçekleştirilir

            string decodedRefreshToken = Uri.UnescapeDataString(refreshToken);

            // Kullanıcıyı refresh token ile veritabanından bul
            User user = await _userManager.GetBy(x => x.RefreshToken == decodedRefreshToken);

            if (user != null && user.RefreshTokenEndDate > DateTime.Now)
            {
                return GenerateTokenResponse(user);
            }

            return null; // Oturum yenileme başarısız
        }

        private UserLoginResponse GenerateTokenResponse(User user)
        {
            // Token oluşturma işlemleri burada gerçekleştirilir

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            DateTime tokenExpireDate = DateTime.Now.AddMinutes(60); // Token süresini belirleyin
            DateTime refreshTokenExpireDate = tokenExpireDate.AddHours(5); // Refresh token süresini belirleyin

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
                expires: tokenExpireDate,
                signingCredentials: signingCredentials
            );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            string authToken = tokenHandler.WriteToken(jwt);

            byte[] number = new byte[32];
            RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(number);

            string refreshToken = Convert.ToBase64String(number);

            // Kullanıcıya refreshToken'i kaydetmek ve son kullanma tarihini ayarlamak için veritabanına güncelleme işlemi yapılmalıdır

            UserLoginResponse response = new UserLoginResponse
            {
                AuthenticateResult = true,
                AuthToken = authToken,
                AccessTokenExpireDate = tokenExpireDate,
                RefreshToken = refreshToken
            };

            return response;
        }
    }
}
