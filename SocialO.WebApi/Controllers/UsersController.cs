using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialO.BL.Abstract;
using SocialO.BL.Models.UserModels;
using SocialO.Entities.Concrete;
using SocialO.WebApi.Models.UserModels.Register;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly IUserManager _userManager;

    public UsersController(IUserManager userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var users = await _userManager.GetAllAsync();

        if (users == null) return NotFound();

        return Ok(users);
    }

    [HttpGet("{username}")]
    public async Task<ActionResult<UserProfileModel>> GetUser(string username)
    {
        var model = await _userManager.GetUserByUsername(username);

        if (model == null) return NotFound();

        return Ok(model);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(int id, User user)
    {
        if (id != user.Id) return BadRequest();

        var updateResult = await _userManager.UpdateAsync(user);

        if (updateResult == 0) return NotFound();

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<User>> PostUser(User user)
    {
        var result = await _userManager.InsertAsync(user);

        if (result <= 0) return Problem("Entity set 'SqlDBContext.Users' is null.");

        return CreatedAtAction("GetUser", new { id = user.Id }, user);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> StatusChangerUser(int id)
    {
        var success = await _userManager.ChangeUserStatus(id);

        if (!success) return NotFound();

        return NoContent();
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<bool>> CreateUser(UserRegister userRegister)
    {
        var created = await _userManager.CreateUser(userRegister);

        if (!created) return BadRequest();

        return true;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<UserCardModel>>> SearchByName(string searchedString)
    {
        var users = await _userManager.SearchUsersByName(searchedString);

        if (users == null) return NotFound();

        return Ok(users);
    }
}