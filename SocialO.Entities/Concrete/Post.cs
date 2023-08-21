using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialO.Entities.Concrete
{
    public class Post
    {
        Guid PostId { get; set; }
        string Content { get; set; }
        DateTime DatePosted { get; set; } = DateTime.Now;

        //User
        Guid UserId { get; set; }
        User User { get; set; }

        //PostComment
        Guid? PostCommentId { get; set; }
        ICollection<PostComment>? PostComments { get; set; }

        //PostFavorite
        Guid? PostFavoriteId { get; set; }
        ICollection<PostFavorite>? PostFavorites { get; set; }


    }
}