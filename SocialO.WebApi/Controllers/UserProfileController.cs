using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialO.BL.Abstract;
using SocialO.WebApi.Models.UserProfile;

namespace SocialO.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserProfileController : ControllerBase
{
    private readonly IUserProfileManager _userProfileManager;

    public UserProfileController(IUserProfileManager userProfileManager)
    {
        _userProfileManager = userProfileManager;
    }

    [HttpGet]
    public async Task<ActionResult<EditUserProfileModel>> GetProfile(int userId)
    {
        var profile = await _userProfileManager.GetUserProfile(userId);

        if (profile == null) return NotFound();

        return Ok(profile);
    }

    [HttpPut]
    public async Task<IActionResult> PutProfile([FromBody] EditUserProfileModel userProfileModel)
    {
        var updated = await _userProfileManager.UpdateUserProfile(userProfileModel);

        if (!updated) return BadRequest();

        return Ok();
    }
}