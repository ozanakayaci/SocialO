namespace SocialO.WebApi.Models.UsersModels.Profile
{
	public class UserProfileDto
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public char Gender { get; set; }
		public string? About { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public DateTime DateRegistered { get; set; }
		public int PostCount { get; set; }
		public int FollowerCount { get; set; }
		public int FollowingCount { get; set; }
		public int FavoriteCount { get; set; }

	}
}
