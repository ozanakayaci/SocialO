using SocialO.BL.Models.UserModels;
using SocialO.Entities.Concrete;
using SocialO.WebApi.Models.UserModels.Register;

namespace SocialO.BL.Abstract
{
    public interface IUserManager : IManagerBase<User>
    {
        Task<IEnumerable<UserCardModel>> SearchUsersByName(string searchedString);
        Task<UserProfileModel> GetUserByUsername(string username);
        Task<bool> CreateUser(UserRegister userRegister);
        Task<bool> ChangeUserStatus(int userId);
    }
}