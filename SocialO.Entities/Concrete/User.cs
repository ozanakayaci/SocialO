using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialO.Entities.Concrete
{
    public class User
    {
        Guid UserId { get; set; }
        string Username { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        DateTime DataRegistered { get; set; } = DateTime.Now;
        string UserType { get; set; } = "User";
        string AccountStatus { get; set; } = "Active";

        //other entities 
        // UserProfile
        Guid? UserProfileId { get; set; }
        UserProfile? UserProfile { get; set; }

        //FollowerRelationship
        Guid? FollowerRelationshipId { get; set; }
        ICollection<FollowerRelationship>? FollowerRelationships { get; set; }

        //Post
        Guid? PostId { get; set; }
        ICollection<Post>? Post { get; set; }

        //PostComment
        Guid? PostCommentId { get; set; }
        ICollection<PostComment>? PostComments { get; set; }

        //PostFavorite
        Guid? PostFavoriteId { get; set; }
        ICollection<PostFavorite>? PostFavorites { get; set; }


    }
}