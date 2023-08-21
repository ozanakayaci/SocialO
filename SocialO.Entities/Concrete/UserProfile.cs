using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialO.Entities.Abstract;

namespace SocialO.Entities.Concrete
{
    public class UserProfile : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public char? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? About { get; set; }
        public DateTime DateUpdated { get; set; }

        //User
        public int UserId { get; set; }
        public User User { get; set; }

    }
}