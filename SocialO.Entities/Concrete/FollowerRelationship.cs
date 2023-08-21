using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialO.Entities.Concrete
{
    public class FollowerRelationship
    {

        Guid FollowerRelationshipId { get; set; }

        Guid FollowerId { get; set; }
        User Follower { get; set; }

        //User
        Guid UserId { get; set; }
        User User { get; set; }


    }
}