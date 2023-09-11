using SocialO.BL.Abstract;
using SocialO.Entities.Concrete;

namespace SocialO.BL.Concrete
{
    public class PostCommentManager : ManagerBase<PostComment>, IPostCommentManager
    {
        public PostCommentManager(DAL.Repository.Abstract.IBaseRepository<PostComment> repository) : base(repository)
        {
        }
    }
}