using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialO.BL.Abstract;
using SocialO.BL.Concrete;
using SocialO.DAL.DBContexts;
using SocialO.Entities.Concrete;
using SocialO.WebApi.Models.UserModels.Register;
using SocialO.WebApi.Models.UserProfile;

namespace SocialO.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {

        private readonly SqlDBContext _context;
        private readonly UserProfileManager _userProfileManager;

        public UserProfileController(SqlDBContext context)
        {
            _context = context;
            _userProfileManager = new UserProfileManager();
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

            return Ok(result);
        }



    }
}
