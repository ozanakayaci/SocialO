using SocialO.Entities.Concrete;

namespace SocialO.BL.Abstract
{
    public interface IPostFavoriteManager : IManagerBase<PostFavorite>
    {

        Task<bool> TogglePostFavorite(int postId, int userId);
        Task<bool> IsLiked(int postId, int userId);

    }
}