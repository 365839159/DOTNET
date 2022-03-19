using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediatRSample.Domains.UserInfo
{
    public class UserInfoEntityConfig : IEntityTypeConfiguration<UserInfoEntity>
    {
        public void Configure(EntityTypeBuilder<UserInfoEntity> builder)
        {
            builder.ToTable("UserInfo");
            builder.Property("passwordHash");
            builder.Property(s => s.Remark).HasField("remark");
            builder.Ignore(s => s.Tag);
        }
    }
}
