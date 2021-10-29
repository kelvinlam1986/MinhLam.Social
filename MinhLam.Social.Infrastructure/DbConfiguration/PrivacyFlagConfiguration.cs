using MinhLam.Social.Domain.Profiles;
using System;
using System.Data.Entity.ModelConfiguration;

namespace MinhLam.Social.Infrastructure.DbConfiguration
{
    public class PrivacyFlagConfiguration : EntityTypeConfiguration<PrivacyFlag>
    {
        public PrivacyFlagConfiguration()
        {
            this.ToTable("PrivacyFlags");
            this.HasKey<Guid>(x => x.Id);
            this.Property(x => x.CreatedDate).IsRequired();
        }
    }
}
