using Microsoft.EntityFrameworkCore;
using SocialO.BL.Abstract;
using SocialO.Entities.Concrete;
using SocialO.WebApi.Models.UserProfile;

namespace SocialO.BL.Concrete
{
    public class UserProfileManager : ManagerBase<UserProfile>, IUserProfileManager
    {


        public async Task<EditUserProfileModel> GetUserProfile(int userId)
        {
            var profile = await base.repository.dbContext.UserProfiles
                .FirstOrDefaultAsync(up => up.UserId == userId);

            if (profile == null)
            {
                return null;
            }

            return new EditUserProfileModel
            {
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                About = profile.About,
                DateOfBirth = profile.DateOfBirth
            };
        }

        public async Task<bool> UpdateUserProfile(EditUserProfileModel userProfileModel)
        {
            var existUserProfile = await base.repository.dbContext.UserProfiles
                .FirstOrDefaultAsync(up => up.UserId == userProfileModel.UserId);

            if (existUserProfile == null)
            {
                return false;
            }

            existUserProfile.FirstName = userProfileModel.FirstName;
            existUserProfile.LastName = userProfileModel.LastName;
            existUserProfile.Gender = userProfileModel.Gender;
            existUserProfile.DateOfBirth = userProfileModel.DateOfBirth;
            existUserProfile.About = userProfileModel.About;
            existUserProfile.DateUpdated = DateTime.Now;

            await base.repository.dbContext.SaveChangesAsync();

            return true;
        }
    }
}