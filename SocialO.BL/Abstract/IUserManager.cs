using SocialO.BL.Models.UserModels;
using SocialO.Entities.Concrete;

namespace SocialO.BL.Abstract
{
    public interface IUserManager : IManagerBase<User>
    {
        Task<UserProfileModel> GetUserByUsername(string username);
    }
}