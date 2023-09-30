using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialO.BL.Concrete;
using SocialO.DAL.DBContexts;
using SocialO.Entities.Concrete;
using SocialO.WebApi.Models.UserModels.Register;
using SocialO.WebApi.Models.UsersModels.Profile;
using SocialO.WebApi.Services;

namespace SocialO.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SqlDBContext _context;
        private readonly UserManager _userManager;

        public UsersController(SqlDBContext context)
        {
            _context = context;

            _userManager = new UserManager();
        }

        // GET: api/Users
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{username}")]
        
        public async Task<ActionResult<UserProfileDto>> GetUser(string username)
        {
            var user = await _context.Users.Where(u=> u.Username == username)
				.Include(u => u.UserProfile)
				.Include(u => u.Posts)
				.Include(u => u.Followers)
				.Include(u => u.Following)
				.Include(u => u.PostFavorites)
				.FirstOrDefaultAsync();

            if (user == null)
            {
				return NotFound();
			}
            var dto = new UserProfileDto {
                Id = user.Id,
                Username = username,
                FirstName = user.UserProfile.FirstName,
                LastName = user.UserProfile.LastName,
                Gender = (char)user.UserProfile.Gender,
                About = user.UserProfile.About,
                DateOfBirth = user.UserProfile.DateOfBirth,
                DateRegistered = user.DataRegistered,
                PostCount = user.Posts.Count,
                FollowerCount = user.Followers.Count,
                FollowingCount = user.Following.Count,
                FavoriteCount = user.PostFavorites.Count


            };


            return dto;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from over-posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'SqlDBContext.Users'  is null.");
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> StatusChangerUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            user.AccountStatus = user.AccountStatus == "Active" ? "Deactive" : "Active";
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("[action]")]
        public async Task<bool> CreateUser([FromForm] UserRegister userRegister)
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

            int result = await _userManager.InsertAsync(user);

            return result > 0 ? true : false;
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
