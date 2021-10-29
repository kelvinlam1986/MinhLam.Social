using MinhLam.Social.Domain.Memberships;
using System;
using System.Data.Entity.ModelConfiguration;

namespace MinhLam.Social.Infrastructure.DbConfiguration
{
    public class AccountConfiguration : EntityTypeConfiguration<Account>
    {
        public AccountConfiguration()
        {
            this.ToTable("Accounts");
            this.HasKey<Guid>(x => x.Id);
            this.Property(x => x.FirstName)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(30);
            this.Property(x => x.LastName)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(30);
            this.Property(x => x.EmailVerified)
                .IsRequired();
            this.Property(x => x.CreatedDate).IsRequired();
            this.Property(x => x.LastUpdated).IsRequired();
            this.HasMany(x => x.Permissions)
                .WithMany(x => x.Accounts)
                .Map(x =>
                {
                    x.MapLeftKey("AccountId");
                    x.MapRightKey("PermissionId");
                });
        }
    }
}
