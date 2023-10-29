using Microsoft.EntityFrameworkCore;
using SocialO.BL.Abstract;
using SocialO.BL.Models.PostModels;
using SocialO.Entities.Concrete;

namespace SocialO.BL.Concrete
{
    public class PostManager : ManagerBase<Post>, IPostManager
    {
        public Task<GetPostDto> GetPostById(int id)
        {
            var post = base.repository.dbContext.Posts
                .Where(p => p.Id == id)
                .Select(
                    p =>
                        new GetPostDto
                        {
                            AuthorName = p.User.UserProfile.FirstName,
                            AuthorUsername = p.User.Username,
                            PostId = p.Id,
                            Content = p.Content,
                            DatePosted = p.DatePosted,
                            AuthorId = p.AuthorId,
                            CommentCount = p.PostComments.Count,
                            FavoriteCount = p.PostFavorites.Count
                        }
                )
                .FirstOrDefaultAsync();

            return post;
        }

        public async Task<IEnumerable<GetPostDto>> GetAllPostById(
            int followerId,
            int page,
            int pageSize,
            bool isOwnPost
        )
        {
            var posts = await base.repository.dbContext.Posts
                .Where(
                    p =>
                        p.User.Following.Any(
                            f =>
                                (
                                    isOwnPost
                                        ? (f.UserId == followerId)
                                        : (f.FollowerId == followerId || f.UserId == followerId)
                                )
                        )
                )
                .OrderByDescending(p => p.DatePosted)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(
                    p =>
                        new GetPostDto
                        {
                            AuthorName = p.User.UserProfile.FirstName,
                            AuthorUsername = p.User.Username,
                            PostId = p.Id,
                            Content = p.Content,
                            DatePosted = p.DatePosted,
                            AuthorId = p.AuthorId,
                            CommentCount = p.PostComments.Count,
                            FavoriteCount = p.PostFavorites.Count
                        }
                )
                .ToListAsync();

            return posts;
        }
    }
}
