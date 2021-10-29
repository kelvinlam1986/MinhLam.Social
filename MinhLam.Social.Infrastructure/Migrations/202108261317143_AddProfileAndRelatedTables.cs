namespace MinhLam.Social.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProfileAndRelatedTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LevelOfExperiences",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        SortOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProfileAttributes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProfileAttributeTypeId = c.Guid(nullable: false),
                        ProfileId = c.Guid(nullable: false),
                        Response = c.String(maxLength: 2000),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profiles", t => t.ProfileId, cascadeDelete: true)
                .ForeignKey("dbo.ProfileAttributeTypes", t => t.ProfileAttributeTypeId, cascadeDelete: true)
                .Index(t => t.ProfileAttributeTypeId)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AccountId = c.Guid(nullable: false),
                        AolAccountName = c.String(maxLength: 50, unicode: false),
                        IcqAccountName = c.String(maxLength: 50, unicode: false),
                        GoogleAccountName = c.String(maxLength: 50, unicode: false),
                        MsnAccountName = c.String(maxLength: 50, unicode: false),
                        SkypeAccountName = c.String(maxLength: 50, unicode: false),
                        YahooAccountName = c.String(maxLength: 50),
                        LevelOfExperienceId = c.Guid(nullable: false),
                        YearOfFirstTank = c.Int(nullable: false),
                        NumberOfTanksOwned = c.Int(nullable: false),
                        NumberOfFishOwned = c.Int(nullable: false),
                        Signature = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.LevelOfExperiences", t => t.LevelOfExperienceId, cascadeDelete: true)
                .Index(t => t.AccountId)
                .Index(t => t.LevelOfExperienceId);
            
            CreateTable(
                "dbo.ProfileAttributeTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        SortOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProfileAttributes", "ProfileAttributeTypeId", "dbo.ProfileAttributeTypes");
            DropForeignKey("dbo.ProfileAttributes", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.Profiles", "LevelOfExperienceId", "dbo.LevelOfExperiences");
            DropForeignKey("dbo.Profiles", "AccountId", "dbo.Accounts");
            DropIndex("dbo.Profiles", new[] { "LevelOfExperienceId" });
            DropIndex("dbo.Profiles", new[] { "AccountId" });
            DropIndex("dbo.ProfileAttributes", new[] { "ProfileId" });
            DropIndex("dbo.ProfileAttributes", new[] { "ProfileAttributeTypeId" });
            DropTable("dbo.ProfileAttributeTypes");
            DropTable("dbo.Profiles");
            DropTable("dbo.ProfileAttributes");
            DropTable("dbo.LevelOfExperiences");
        }
    }
}
