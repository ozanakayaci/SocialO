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
            builder.Property(p => p.PasswordSalt).IsRequired();
            builder.Property(p => p.PasswordHash).IsRequired();
            builder.Property(p => p.DataRegistered).HasDefaultValueSql("datetime('now')");
            builder.Property(p => p.UserType).HasDefaultValue("User");
            builder.Property(p => p.AccountStatus).HasDefaultValue("Active");

            builder.HasOne(p => p.UserProfile).WithOne(p => p.User).HasForeignKey<UserProfile>(p => p.UserId);

            builder.HasMany(p => p.Posts).WithOne(p => p.User).HasForeignKey(p => p.AuthorId);

            builder.HasMany(p => p.PostComments).WithOne(p => p.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.PostFavorites).WithOne(p => p.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}