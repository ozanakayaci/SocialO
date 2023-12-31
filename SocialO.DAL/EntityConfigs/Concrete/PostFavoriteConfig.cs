using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialO.DAL.EntityConfigs.Abstract;
using SocialO.Entities.Concrete;

namespace SocialO.DAL.EntityConfigs.Concrete
{
    public class PostFavoriteConfig : BaseConfig<PostFavorite>
    {
        public override void Configure(EntityTypeBuilder<PostFavorite> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.DateFavorited).HasDefaultValueSql("datetime('now')");


        }
    }
}