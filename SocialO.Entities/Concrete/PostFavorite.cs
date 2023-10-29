using SocialO.Entities.Abstract;

namespace SocialO.Entities.Concrete
{
    public class PostFavorite : BaseEntity
    {


        public DateTime DateFavorited { get; set; }

        //User
        public int UserId { get; set; }
        public User User { get; set; }

        //Post
        public int PostId { get; set; }
        public Post Post { get; set; }

    }
}