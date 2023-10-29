using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialO.DAL.EntityConfigs.Abstract;
using SocialO.Entities.Concrete;

namespace SocialO.DAL.EntityConfigs.Concrete
{
    public class FollowerRelationshipConfig : BaseConfig<FollowerRelationship>
    {
        public override void Configure(EntityTypeBuilder<FollowerRelationship> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.DateFollowed).HasDefaultValueSql("datetime('now')");

            builder.HasOne(p => p.Follower).WithMany(p => p.Followers).HasForeignKey(p => p.FollowerId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.User).WithMany(p => p.Following).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);


        }
    }
}