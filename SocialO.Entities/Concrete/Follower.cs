using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialO.Entities.Abstract;

namespace SocialO.Entities.Concrete
{
    public class Follower : BaseEntity
    {

        public DateTime DateFollowed { get; set; }

        //User
        public Guid? UserId { get; set; }
        public User? User { get; set; }


    }
}