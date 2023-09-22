using Microsoft.AspNetCore.Mvc;
using SocialO.BL.Abstract;
using SocialO.Entities.Concrete;

namespace SocialO.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FollowerRelationshipsController : ControllerBase
	{
		private readonly IFollowerRelationshipManager _followerManager;
		private readonly IUserManager _userManager;

		public FollowerRelationshipsController(IFollowerRelationshipManager followerManager, IUserManager userManager)
		{
			_followerManager = followerManager;
			_userManager = userManager;
		}

		// GET: api/FollowerRelationships
		[HttpGet]
		public async Task<ICollection<FollowerRelationship>> GetFollowerRelationships()
		{




			return await _followerManager.GetAllAsync();
		}

		// GET: api/FollowerRelationships/5
		[HttpGet("{userId}")]
		public async Task<ICollection<FollowerRelationship>> GetFollowers(int userId)
		{


			var followers = await _followerManager.GetAllAsync(x => x.UserId == userId);



			if (followers == null)
			{
				return null;
			}

			return followers;
		}



		// POST: api/FollowerRelationships
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<bool> FollowUnfollow(int followerId, int userId,bool isFollowed=false)
		{

			var follower = _userManager.GetBy(p => p.Id == followerId).Result;
			var followed = _userManager.GetBy(p => p.Id == userId).Result;

			if (follower != null && followed != null)
			{
				if (isFollowed)
				{
					FollowerRelationship relation = await _followerManager.GetBy(p => (p.FollowerId == followerId && p.UserId == userId));

					_followerManager.DeleteAsync(relation);

					return true;
				}

				FollowerRelationship followerRelationship = new FollowerRelationship
				{
					FollowerId = followerId,
					UserId = userId,
					
				};

				int result = await _followerManager.InsertAsync(followerRelationship);

				return result > 0 ? true : false;
			}

			return false;

		}



	}
}
