using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialO.WebApi.Models
{
    public class UserLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}