using SocialO.BL.Abstract;
using SocialO.Entities.Concrete;

namespace SocialO.BL.Concrete
{
    public class PostFavoriteManager : ManagerBase<PostFavorite>, IPostFavoriteManager
    {
        public PostFavoriteManager(DAL.Repository.Abstract.IBaseRepository<PostFavorite> repository) : base(repository)
        {
        }
    }
}