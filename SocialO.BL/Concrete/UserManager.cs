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
                .Include(u => u.Following)
                .Include(u => u.Followers)
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
                    Gender = user.UserProfile.Gender,
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

        public async Task<IEnumerable<UserCardModel>> GetUsersBySearch(string searchedString)
        {
	        var users = await base.repository.dbContext.Users
		        .Where(x => x.Username.Contains(searchedString))
		        .Include(u => u.UserProfile)
                .Include(u => u.Followers)
                .Include(u => u.Following)
                .ToListAsync();

	        var model = new List<UserCardModel>();

	        foreach (var user in users)
	        {
                if (user.UserProfile != null)
                {
                    UserCardModel userModel = new UserCardModel
                    {
                        Id = user.Id,
                        Username = user.Username,
                        Name = user.UserProfile.FirstName,
                        About = user.UserProfile?.About,
                        FollowerCount = user.Followers.Count,
                        FollowingCount = user.Following.Count,

                    };

		        model.Add(userModel);
                }
                else
                {
                    UserCardModel userModel = new UserCardModel
                    {
                        Id = user.Id,
                        Username = user.Username,
                        FollowerCount = user.Followers.Count,
                        FollowingCount = user.Following.Count,

                    };

                    model.Add(userModel);
                }
               

	        }

			return model;
        }
    }
}
