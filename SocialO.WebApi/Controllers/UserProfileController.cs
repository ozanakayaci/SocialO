using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialO.BL.Concrete;
using SocialO.DAL.DBContexts;
using SocialO.WebApi.Models.UserProfile;

namespace SocialO.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserProfileController : ControllerBase
    {

        private readonly SqlDBContext _context;
        private readonly UserProfileManager _userProfileManager;

        public UserProfileController(SqlDBContext context)
        {
            _context = context;
            _userProfileManager = new UserProfileManager();
        }

        [HttpGet]
        public async Task<ActionResult<EditUserProfileModel>> GetProfile(int userId)
        {
            var profile = _userProfileManager.GetBy(up => up.UserId == userId).Result;

            var profileModel = new EditUserProfileModel
            {
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                About = profile.About,
                DateOfBirth = profile.DateOfBirth,
            };


            return Ok(profileModel);


        }

        [HttpPut]
        public async Task<IActionResult> PutProfile([FromBody] EditUserProfileModel userProfileModel)
        {

            var existUserProfile = _userProfileManager.GetBy(up => up.UserId == userProfileModel.UserId).Result;

            if (existUserProfile == null)
            {
                return BadRequest();

            }

            existUserProfile.FirstName = userProfileModel.FirstName;
            existUserProfile.LastName  = userProfileModel.LastName;
            existUserProfile.Gender = userProfileModel.Gender;
            existUserProfile.DateOfBirth = userProfileModel.DateOfBirth;
            existUserProfile.About = userProfileModel.About;
            existUserProfile.DateUpdated = DateTime.Now;
            
            int result = _userProfileManager.UpdateAsync(existUserProfile).Result;

            return Ok();
        }



    }
}
