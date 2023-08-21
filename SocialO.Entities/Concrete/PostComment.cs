using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialO.Entities.Concrete
{
    public class PostComment
    {
        Guid PostCommentId { get; set; }
        string Comment { get; set; }
        DateTime DateCommented { get; set; } = DateTime.Now;

        //User
        Guid UserId { get; set; }
        User User { get; set; }

        //Post
        Guid PostId { get; set; }
        Post Post { get; set; }
    }
}
