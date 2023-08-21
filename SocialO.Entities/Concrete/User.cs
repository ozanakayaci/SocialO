using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialO.Entities.Abstract;

namespace SocialO.Entities.Concrete
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DataRegistered { get; set; }
        public string UserType { get; set; }
        public string AccountStatus { get; set; }

        //other entities 
        // UserProfile       
        public UserProfile? UserProfile { get; set; }

        //Follower
        public ICollection<Follower>? Followers { get; set; }

        //Post
        public ICollection<Post>? Posts { get; set; }

        //PostComment
        public ICollection<PostComment>? PostComments { get; set; }

        //PostFavorite
        public ICollection<PostFavorite>? PostFavorites { get; set; }


    }
}