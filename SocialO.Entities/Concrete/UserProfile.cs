using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialO.Entities.Concrete
{
    public class UserProfile
    {
        Guid UserProfileId { get; set; }
        string? FirstName { get; set; }
        string? LastName { get; set; }
        char? Gender { get; set; }
        DateTime? DateOfBirth { get; set; }
        string? About { get; set; }
        DateTime DateUpdated { get; set; } = DateTime.Now;

        //User
        Guid UserId { get; set; }
        User User { get; set; }

    }
}