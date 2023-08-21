using System.Collections.Immutable;
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
    public class UserConfig : BaseConfig<User>
    {

        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.HasIndex(p => p.Username).IsUnique();
            builder.Property(p => p.Username).IsRequired().HasMaxLength(20);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Password).IsRequired().HasMaxLength(20);
            builder.Property(p => p.DataRegistered).HasDefaultValue(DateTime.Now);
            builder.Property(p => p.UserType).HasDefaultValue("User");
            builder.Property(p => p.AccountStatus).HasDefaultValue("Active");

            builder.HasOne(p => p.UserProfile).WithOne(p => p.User).HasForeignKey<UserProfile>(p => p.UserId);

            builder.HasMany(p => p.Posts).WithOne(p => p.User).HasForeignKey(p => p.UserId);

            builder.HasMany(p => p.PostComments).WithOne(p => p.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.PostFavorites).WithOne(p => p.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);


            builder.HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Email = "admin@socialo.com",
                    Password = "admin",
                    DataRegistered = DateTime.Now,
                    UserType = "Admin",
                    AccountStatus = "Active"
                }, new User
                {
                    Id = 2,
                    Username = "user1",
                    Email = "user1@socialo.com",
                    Password = "user1",
                    DataRegistered = DateTime.Now,
                    UserType = "User",
                    AccountStatus = "Active"
                }, new User
                {
                    Id = 3,
                    Username = "user2",
                    Email = "user2@socialo.com",
                    Password = "user2",
                    DataRegistered = DateTime.Now,
                    UserType = "User",
                    AccountStatus = "Active"
                }

            );




        }
    }
}