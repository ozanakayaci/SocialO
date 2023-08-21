using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialO.Entities.Concrete
{
    public class PostFavorite
    {

        Guid PostFavoriteId { get; set; }
        DateTime DateFavorited { get; set; } = DateTime.Now;

        //User
        Guid UserId { get; set; }
        User User { get; set; }

        //Post
        Guid PostId { get; set; }
        Post Post { get; set; }

    }
}