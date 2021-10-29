using MinhLam.Social.Domain.Memberships;
using System;
using System.Data.Entity.ModelConfiguration;

namespace MinhLam.Social.Infrastructure.DbConfiguration
{
    public class TermConfiguration : EntityTypeConfiguration<Term>
    {
        public TermConfiguration()
        {
            this.ToTable("Terms");
            this.HasKey<Guid>(x => x.Id);
            this.Property(x => x.Terms)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(500);
            this.Property(x => x.CreatedDate)
                .IsRequired();
        }
    }
}
