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
    public class PostFavoriteConfig : BaseConfig<PostFavorite>
    {
        public override void Configure(EntityTypeBuilder<PostFavorite> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.DateFavorited).HasDefaultValue(DateTime.Now);


        }
    }
}