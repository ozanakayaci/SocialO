using SocialO.Entities.Concrete;
using SocialO.WebApi.Models.UserProfile;

namespace SocialO.BL.Abstract
{
    public interface IUserProfileManager : IManagerBase<UserProfile>
    {
        Task<EditUserProfileModel> GetUserProfile(int userId);
        Task<bool> UpdateUserProfile(EditUserProfileModel userProfileModel);
    }
}