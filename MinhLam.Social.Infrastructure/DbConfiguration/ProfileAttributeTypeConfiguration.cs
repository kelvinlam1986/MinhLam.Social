using MinhLam.Social.Domain.Profiles;
using System;
using System.Data.Entity.ModelConfiguration;

namespace MinhLam.Social.Infrastructure.DbConfiguration
{
    public class ProfileAttributeTypeConfiguration : EntityTypeConfiguration<ProfileAttributeType>
    {
        public ProfileAttributeTypeConfiguration()
        {
            this.ToTable("ProfileAttributeTypes");
            this.HasKey<Guid>(x => x.Id);
            this.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(50);
            this.Property(x => x.SortOrder)
                .IsRequired();
        }
    }
}
