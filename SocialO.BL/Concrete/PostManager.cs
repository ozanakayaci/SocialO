using SocialO.BL.Abstract;
using SocialO.DAL.Repository.Abstract;
using SocialO.Entities.Concrete;

namespace SocialO.BL.Concrete
{
	public class PostManager : ManagerBase<Post>, IPostManager
	{
		public PostManager(IBaseRepository<Post> repository) : base(repository)
		{
		}
	}
}