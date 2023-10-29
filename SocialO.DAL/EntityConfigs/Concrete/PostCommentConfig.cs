using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialO.DAL.EntityConfigs.Abstract;
using SocialO.Entities.Concrete;

namespace SocialO.DAL.EntityConfigs.Concrete
{
    public class PostCommentConfig : BaseConfig<PostComment>
    {
        public override void Configure(EntityTypeBuilder<PostComment> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Comment).IsRequired().HasMaxLength(500);
            builder.Property(p => p.DateCommented).HasDefaultValueSql("datetime('now')");


        }
    }
}