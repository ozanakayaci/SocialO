using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialO.Entities.Abstract;

namespace SocialO.Entities.Concrete
{
    public class PostComment : BaseEntity
    {

        public string Comment { get; set; }
        public DateTime DateCommented { get; set; }

        //User        
        public int UserId { get; set; }
        public User User { get; set; }

        //Post
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
