using MinhLam.Social.Domain.Profiles;
using System;
using System.Data.Entity.ModelConfiguration;

namespace MinhLam.Social.Infrastructure.DbConfiguration
{
    public class VisibilityConfiguration : EntityTypeConfiguration<Visibility>
    {
        public VisibilityConfiguration()
        {
            this.ToTable("Visibilities");
            this.HasKey<Guid>(x => x.Id);
            this.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(50);
        }
    }
}
