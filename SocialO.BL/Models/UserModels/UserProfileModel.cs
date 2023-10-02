using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialO.BL.Models.UserModels
{
	public class UserProfileModel
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public char? Gender { get; set; }
		public string? About { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public DateTime DateRegistered { get; set; }
		public int PostCount { get; set; } = 0;
		public int FollowerCount { get; set; } = 0;
		public int FollowingCount { get; set; } = 0;
		public int FavoriteCount { get; set; } = 0;
	}
}
