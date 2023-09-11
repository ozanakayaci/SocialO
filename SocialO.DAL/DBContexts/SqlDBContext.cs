using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SocialO.Entities.Concrete;

namespace SocialO.DAL.DBContexts
{
	public class SqlDBContext : DbContext
	{

		public DbSet<User> Users { get; set; }
		public DbSet<UserProfile> UserProfiles { get; set; }
		public DbSet<FollowerRelationship> FollowerRelationships { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<PostComment> PostComments { get; set; }
		public DbSet<PostFavorite> PostFavorites { get; set; }



		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(@"Data Source=SocialO.db");


		}


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}


	}
}