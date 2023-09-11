using SocialO.BL.Abstract;
using SocialO.DAL.Repository.Abstract;
using SocialO.Entities.Concrete;

namespace SocialO.BL.Concrete
{
    public class UserProfileManager : ManagerBase<UserProfile>, IUserProfileManager
    {
        public UserProfileManager(IBaseRepository<UserProfile> repository) : base(repository)
        {
        }
    }
}