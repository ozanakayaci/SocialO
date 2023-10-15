using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialO.BL.Abstract;
using SocialO.DAL.DBContexts;
using SocialO.Entities.Concrete;

namespace SocialO.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowerRelationshipsController : ControllerBase
    {
        private readonly IFollowerRelationshipManager _followerManager;
        private readonly IUserManager _userManager;
        private readonly SqlDBContext _context;

        public FollowerRelationshipsController(
            IFollowerRelationshipManager followerManager,
            IUserManager userManager
        )
        {
            _followerManager = followerManager;
            _userManager = userManager;
            _context = new SqlDBContext();
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
            if (_context.FollowerRelationships == null)
            {
                return null;
            }

            var followers = await _context.FollowerRelationships
                .Where(x => x.UserId == userId)
                .ToListAsync();

            if (followers == null)
            {
                return null;
            }

            return followers;
        }

        // POST: FollowUnfollow
        [HttpPost]
        public async Task<ActionResult> FollowUnfollow(int followerId, int userId)
        {
            var follower = _userManager.GetBy(p => p.Id == followerId).Result;
            var followed = _userManager.GetBy(p => p.Id == userId).Result;

            if ((follower != null && followed != null) && follower.Id != followed.Id)
            {
                FollowerRelationship relation = await _followerManager.GetBy(
                    p => (p.FollowerId == followerId && p.UserId == userId)
                );

                if (relation != null)
                {
                    _followerManager.DeleteAsync(relation);

                    return Ok();
                }

                FollowerRelationship followerRelationship = new FollowerRelationship
                {
                    FollowerId = followerId,
                    UserId = userId,
                };

                int result = await _followerManager.InsertAsync(followerRelationship);

                return result > 0 ? Ok() : NotFound();
            }

            return NotFound();
        }
    }
}
