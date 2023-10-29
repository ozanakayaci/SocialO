using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialO.DAL.EntityConfigs.Abstract;
using SocialO.Entities.Concrete;

namespace SocialO.DAL.EntityConfigs.Concrete
{
    public class UserProfileConfig : BaseConfig<UserProfile>
    {
        public override void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.FirstName).HasMaxLength(20);
            builder.Property(p => p.LastName).HasMaxLength(20);
            builder.Property(p => p.Gender).HasMaxLength(1);
            builder.Property(p => p.About).HasMaxLength(50);
            builder.Property(p => p.DateUpdated).HasDefaultValueSql("datetime('now')");
            builder.Property(p => p.DateOfBirth).HasColumnType("date");


        }
    }
}