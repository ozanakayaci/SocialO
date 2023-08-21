using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialO.Entities.Abstract;

namespace SocialO.Entities.Concrete
{
    public class FollowerRelationship : BaseEntity
    {

        public DateTime DateFollowed { get; set; }

        //Following
        public int? FollowerId { get; set; }
        public User? Follower { get; set; }

        //User
        public int? UserId { get; set; }
        public User? User { get; set; }


    }
}