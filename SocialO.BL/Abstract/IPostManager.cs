using SocialO.Entities.Concrete;
using SocialO.BL.Models.PostModels;

namespace SocialO.BL.Abstract
{
    public interface IPostManager : IManagerBase<Post>
    {

	    Task<GetPostDto> GetPostById(int id);

	    Task<IEnumerable<GetPostDto>> GetAllPostById(int followerId,int page,int pageSize,bool isOwnPost);


    }
}