using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialO.Entities.Abstract;

namespace SocialO.Entities.Concrete
{
    public class Post : BaseEntity
    {

        public string Content { get; set; }
        public DateTime DatePosted { get; set; }
        //User
        public Guid UserId { get; set; }
        public User User { get; set; }

        //PostComment
        public ICollection<PostComment>? PostComments { get; set; }

        //PostFavorite
        public ICollection<PostFavorite>? PostFavorites { get; set; }


    }
}