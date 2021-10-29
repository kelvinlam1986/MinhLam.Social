using MinhLam.Social.Domain.Profiles;
using System;
using System.Data.Entity.ModelConfiguration;

namespace MinhLam.Social.Infrastructure.DbConfiguration
{
    public class ProfileAttributeConfiguration : EntityTypeConfiguration<ProfileAttribute>
    {
        public ProfileAttributeConfiguration()
        {
            this.ToTable("ProfileAttributes");
            this.HasKey<Guid>(x => x.Id);
            this.Property(x => x.Response)
                .HasColumnType("nvarchar")
                .HasMaxLength(2000);
            this.Property(x => x.CreatedDate)
                .IsRequired();
        }
    }
}
