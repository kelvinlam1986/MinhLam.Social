using MinhLam.Social.Domain.Profiles;
using System;
using System.Data.Entity.ModelConfiguration;

namespace MinhLam.Social.Infrastructure.DbConfiguration
{
    public class ProfileConfiguration : EntityTypeConfiguration<Profile>
    {
        public ProfileConfiguration()
        {
            this.ToTable("Profiles");
            this.HasKey<Guid>(x => x.Id);
            this.Property(x => x.AolAccountName)
                .HasColumnType("varchar")
                .HasMaxLength(50);
            this.Property(x => x.IcqAccountName)
                .HasColumnType("varchar")
                .HasMaxLength(50);
            this.Property(x => x.GoogleAccountName)
                .HasColumnType("varchar")
                .HasMaxLength(50);
            this.Property(x => x.MsnAccountName)
                .HasColumnType("varchar")
                .HasMaxLength(50);
            this.Property(x => x.SkypeAccountName)
                .HasColumnType("varchar")
                .HasMaxLength(50);
            this.Property(x => x.YahooAccountName)
                .HasColumnType("varchar")
                .HasMaxLength(50);
            this.Property(x => x.YahooAccountName)
                .HasColumnType("nvarchar")
                .HasMaxLength(50);
        }
    }
}