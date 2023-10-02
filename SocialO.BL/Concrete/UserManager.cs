using Microsoft.EntityFrameworkCore;
using SocialO.BL.Abstract;
using SocialO.BL.Models.UserModels;
using SocialO.Entities.Concrete;

namespace SocialO.BL.Concrete
{
    public class UserManager : ManagerBase<User>, IUserManager
    {
        public async Task<UserProfileModel> GetUserByUsername(string username)
        {
            var user = await base.repository.dbContext.Users
                .Where(u => u.Username == username)
                .Include(u => u.UserProfile)
                .Include(u => u.Posts)
                .Include(u => u.Followers)
                .Include(u => u.Following)
                .Include(u => u.PostFavorites)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new Exception("User not found.");
            }

            if (user.UserProfile != null)
            {
                var model = new UserProfileModel
                {
                    Id = user.Id,
                    Username = username,
                    FirstName = user.UserProfile.FirstName,
                    LastName = user.UserProfile.LastName,
                    Gender = (char)user.UserProfile.Gender,
                    About = user.UserProfile.About,
                    DateOfBirth = user.UserProfile.DateOfBirth,
                    DateRegistered = user.DataRegistered,
                    PostCount = user.Posts.Count,
                    FollowerCount = user.Followers.Count,
                    FollowingCount = user.Following.Count,
                    FavoriteCount = user.PostFavorites.Count
                };

                return model;
            }
            else
            {
                var model = new UserProfileModel
                {
                    Id = user.Id,
                    Username = username,
                    DateRegistered = user.DataRegistered,
                    PostCount = user.Posts.Count,
                    FollowerCount = user.Followers.Count,
                    FollowingCount = user.Following.Count,
                    FavoriteCount = user.PostFavorites.Count
                };
                return model;
            }

        }
    }
}
