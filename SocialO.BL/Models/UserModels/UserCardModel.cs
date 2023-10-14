using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialO.BL.Models.UserModels
{
	public class UserCardModel
	{
		
		public int Id { get; set; }
		public string Username { get; set; }
		public string Name { get; set; }
		public string About { get; set; }

		public int FollowerCount { get; set; }
		public int FollowingCount { get;set; }


    }
}
