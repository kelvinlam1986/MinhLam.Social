using MinhLam.Social.Domain.Profiles;
using System;
using System.Data.Entity.ModelConfiguration;

namespace MinhLam.Social.Infrastructure.DbConfiguration
{
    public class PrivacyFlagTypeConfiguration : EntityTypeConfiguration<PrivacyFlagType>
    {
        public PrivacyFlagTypeConfiguration()
        {
            this.ToTable("PrivacyFlagTypes");
            this.HasKey<Guid>(x => x.Id);
            this.Property(x => x.FieldName)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);
            this.Property(x => x.SortOrder)
                .IsRequired();
        }
    }
}
