using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialO.Entities.Abstract;

namespace SocialO.Entities.Concrete
{
	public class User : BaseEntity
	{
		public string Username { get; set; }
		public string Email { get; set; }
		public byte[] PasswordSalt { get; set; }
		public byte[] PasswordHash { get; set; }
		public DateTime DataRegistered { get; set; }
		public string UserType { get; set; }
		public string AccountStatus { get; set; }

		public string? RefreshToken { get; set; }

		public DateTime? RefreshTokenEndDate { get; set; }

		//other entities 
		// UserProfile       
		public UserProfile? UserProfile { get; set; }

		//FollowerRelationship
		public ICollection<FollowerRelationship>? Followers { get; set; }
		public ICollection<FollowerRelationship>? Following { get; set; }

		//Post
		public ICollection<Post>? Posts { get; set; }

		//PostComment
		public ICollection<PostComment>? PostComments { get; set; }

		//PostFavorite
		public ICollection<PostFavorite>? PostFavorites { get; set; }


	}
}