using MinhLam.Framework;
using MinhLam.Social.Domain.Common;
using MinhLam.Social.Domain.Memberships;
using MinhLam.Social.Domain.Profiles;
using MinhLam.Social.Infrastructure.DbConfiguration;
using System.Data.Entity;
using System.Linq;

namespace MinhLam.Social.Infrastructure
{
    public class SocialContext : DbContext
    {
        public SocialContext() : base("name=Social")
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<ProfileAttribute> ProfileAttributes { get; set; }
        public DbSet<ProfileAttributeType> ProfileAttributeTypes { get; set; }
        public DbSet<LevelOfExperience> LevelOfExperiences { get; set; }
        public DbSet<PrivacyFlag> PrivacyFlags { get; set; }
        public DbSet<PrivacyFlagType> PrivacyFlagTypes { get; set; }
        public DbSet<Visibility> Visibilities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Account
            modelBuilder.ComplexType<Username>().Property(x => x.Value)
                .HasColumnName("Username")
                .IsRequired()
                .HasMaxLength(30);
            modelBuilder.ComplexType<HashedPassword>().Property(x => x.Value)
                .HasColumnName("Password")
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.ComplexType<UserEmail>().Property(x => x.Value)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(150);
            modelBuilder.ComplexType<BirthDate>().Property(x => x.Value)
                .HasColumnName("BirthDate")
                .IsRequired();
            modelBuilder.ComplexType<ZipCode>().Property(x => x.Value)
                .HasColumnName("ZipCode")
                .IsRequired()
                .HasMaxLength(15);
            modelBuilder.Configurations.Add(new AccountConfiguration());

            // Terms
            modelBuilder.Configurations.Add(new TermConfiguration());

            // LevelOFExperience
            modelBuilder.Configurations.Add(new LevelOfExperienceConfiguration());

            // Profile Attribute Type
            modelBuilder.Configurations.Add(new ProfileAttributeTypeConfiguration());

            // Profile Attribute
            modelBuilder.Configurations.Add(new ProfileAttributeConfiguration());

            // Profile
            modelBuilder.ComplexType<TankYear>().Property(x => x.Value)
                .HasColumnName("YearOfFirstTank");
            modelBuilder.Configurations.Add(new ProfileConfiguration());

            // Privacy Flag Type
            modelBuilder.Configurations.Add(new PrivacyFlagTypeConfiguration());

            // Visibility
            modelBuilder.Configurations.Add(new VisibilityConfiguration());

            // Privacy Flag
            modelBuilder.Configurations.Add(new PrivacyFlagConfiguration());
        }

        public override int SaveChanges()
        {
            var domainEntites = ChangeTracker.Entries<AggregateRoot>()
                .Select(x => x.Entity)
                .Where(x => x.DomainEvents.Any())
                .ToArray();

            foreach (var domainEntity in domainEntites)
            {
                DispatchEvents(domainEntity);
            }

            return base.SaveChanges();
        }

        private void DispatchEvents(AggregateRoot aggregateRoot)
        {
            foreach (IDomainEvent domainEvent in aggregateRoot.DomainEvents)
            {
                DomainEvents.Dispatch(domainEvent);
            }

            aggregateRoot.ClearEvents();
        }
    }
}
