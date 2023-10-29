using Microsoft.EntityFrameworkCore;
using SocialO.BL.Abstract;
using SocialO.DAL.DBContexts;
using SocialO.Entities.Concrete;

namespace SocialO.BL.Concrete
{
    public class PostFavoriteManager : ManagerBase<PostFavorite>, IPostFavoriteManager
    {
       

        public async Task<bool> TogglePostFavorite(int postId, int userId)
        {
            PostFavorite relation = await base.repository.dbContext.PostFavorites
                .FirstOrDefaultAsync(p => p.PostId == postId && p.UserId == userId);

            if (relation != null)
            {
                 base.repository.dbContext.PostFavorites.Remove(relation);
            }
            else
            {
                relation = new PostFavorite
                {
                    PostId = postId,
                    UserId = userId,
                };
                 base.repository.dbContext.PostFavorites.Add(relation);
            }

            await  base.repository.dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> IsLiked(int postId, int userId)
        {
            return await  base.repository.dbContext.PostFavorites.AnyAsync(x => x.UserId == userId && x.PostId == postId);
        }
    }
}