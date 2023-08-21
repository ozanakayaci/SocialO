using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            builder.Property(p => p.DateFollowed).HasDefaultValue(DateTime.Now);

            builder.HasOne(p => p.Follower).WithMany(p => p.Followers).HasForeignKey(p => p.FollowerId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.User).WithMany(p => p.Following).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);



            builder.HasData(
              new FollowerRelationship
              {
                  Id = 1,
                  DateFollowed = DateTime.Now,
                  FollowerId = 3,
                  UserId = 1

              }, new FollowerRelationship
              {
                  Id = 2,
                  DateFollowed = DateTime.Now,
                  FollowerId = 3,
                  UserId = 2

              }, new FollowerRelationship
              {
                  Id = 3,
                  DateFollowed = DateTime.Now,
                  FollowerId = 2,
                  UserId = 1

              }, new FollowerRelationship
              {
                  Id = 4,
                  DateFollowed = DateTime.Now,
                  FollowerId = 1,
                  UserId = 3

              }

          );



        }
    }
}