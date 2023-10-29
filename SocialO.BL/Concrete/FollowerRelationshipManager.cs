using Microsoft.EntityFrameworkCore;
using SocialO.BL.Abstract;
using SocialO.Entities.Concrete;

namespace SocialO.BL.Concrete
{
    public class FollowerRelationshipManager : ManagerBase<FollowerRelationship>, IFollowerRelationshipManager
    {
        private readonly IUserManager _userManager;

        public FollowerRelationshipManager(
            IUserManager userManager)
        {
            _userManager = userManager;
        }



        public async Task<ICollection<FollowerRelationship>> GetFollowers(int userId)
        {
            var followers = await base.repository.dbContext.FollowerRelationships
                .Where(x => x.UserId == userId)
                .ToListAsync();

            return followers;
        }


        public async Task<bool> FollowUnfollow(int followerId, int userId)
        {
            var follower = await _userManager.GetBy(p => p.Id == followerId);
            var followed = await _userManager.GetBy(p => p.Id == userId);

            if ((follower != null && followed != null) && follower.Id != followed.Id)
            {
                FollowerRelationship relation = await this.GetBy(
                    p => (p.FollowerId == followerId && p.UserId == userId)
                );

                if (relation != null)
                {
                    await this.DeleteAsync(relation);
                    return true;
                }

                FollowerRelationship followerRelationship = new FollowerRelationship
                {
                    FollowerId = followerId,
                    UserId = userId,
                };

                int result = await this.InsertAsync(followerRelationship);

                return result > 0;
            }

            return false;
        }

    }
}