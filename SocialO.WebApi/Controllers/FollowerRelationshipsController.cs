using Microsoft.AspNetCore.Mvc;
using SocialO.BL.Abstract;
using SocialO.Entities.Concrete;

namespace SocialO.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FollowerRelationshipsController : ControllerBase
{
    private readonly IFollowerRelationshipManager _followerManager;


    public FollowerRelationshipsController(IFollowerRelationshipManager followerManager)
    {
        _followerManager = followerManager;
    }


    // GET: All followerRelationships
    [HttpGet]
    public async Task<ICollection<FollowerRelationship>> GetFollowerRelationships()
    {
        return await _followerManager.GetAllAsync();
    }


    // GET: user followers
    [HttpGet("{userId}")]
    public async Task<ActionResult<ICollection<FollowerRelationship>>> GetFollowers(int userId)
    {
        var followers = await _followerManager.GetFollowers(userId);

        if (followers == null) return NotFound(); // veya BadRequest() gibi uygun bir sonuç dönebilir

        return Ok(followers);
    }


    // POST: FollowUnfollow
    [HttpPost]
    public async Task<ActionResult> FollowUnfollow(int followerId, int userId)
    {
        var result = await _followerManager.FollowUnfollow(followerId, userId);

        if (result) return Ok();

        return NotFound();
    }
}