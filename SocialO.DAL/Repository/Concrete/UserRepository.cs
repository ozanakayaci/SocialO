using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialO.DAL.Repository.Abstract;
using SocialO.Entities.Concrete;

namespace SocialO.DAL.Repository.Concrete
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

    }
}