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
    public class PostConfig : BaseConfig<Post>
    {
        public override void Configure(EntityTypeBuilder<Post> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Content).IsRequired().HasMaxLength(500);
            builder.Property(p => p.DatePosted).HasDefaultValueSql("datetime('now')");

            builder.HasMany(p => p.PostComments).WithOne(p => p.Post).HasForeignKey(p => p.PostId);

            builder.HasMany(p => p.PostFavorites).WithOne(p => p.Post).HasForeignKey(p => p.PostId);

        }
    }
}