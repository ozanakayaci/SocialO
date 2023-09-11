using SocialO.BL.Abstract;
using SocialO.DAL.Repository.Abstract;
using SocialO.Entities.Concrete;

namespace SocialO.BL.Concrete
{
    public class FollowerRelationshipManager : ManagerBase<FollowerRelationship>, IFollowerRelationshipManager
    {
        public FollowerRelationshipManager(IBaseRepository<FollowerRelationship> repository) : base(repository)
        {
        }
    }
}