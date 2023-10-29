using SocialO.Entities.Concrete;

namespace SocialO.BL.Abstract
{
    public interface IFollowerRelationshipManager : IManagerBase<FollowerRelationship>
    {
        Task<ICollection<FollowerRelationship>> GetFollowers(int userId);
        Task<bool> FollowUnfollow(int followerId, int userId);
    }
}