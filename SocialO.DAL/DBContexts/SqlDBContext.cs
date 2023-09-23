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

		public SqlDBContext()
		{
		}

		public SqlDBContext(DbContextOptions<SqlDBContext> options)
			: base(options)
		{
		}



		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=.;Database=SocialODB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");


		}


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}


	}
}