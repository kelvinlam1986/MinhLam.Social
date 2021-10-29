namespace MinhLam.Social.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPrivacyTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PrivacyFlags",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PrivacyFlagTypeId = c.Guid(nullable: false),
                        ProfileId = c.Guid(nullable: false),
                        VisibilityId = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PrivacyFlagTypes", t => t.PrivacyFlagTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Profiles", t => t.ProfileId, cascadeDelete: true)
                .ForeignKey("dbo.Visibilities", t => t.VisibilityId, cascadeDelete: true)
                .Index(t => t.PrivacyFlagTypeId)
                .Index(t => t.ProfileId)
                .Index(t => t.VisibilityId);
            
            CreateTable(
                "dbo.PrivacyFlagTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FieldName = c.String(nullable: false, maxLength: 50, unicode: false),
                        SortOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Visibilities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PrivacyFlags", "VisibilityId", "dbo.Visibilities");
            DropForeignKey("dbo.PrivacyFlags", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.PrivacyFlags", "PrivacyFlagTypeId", "dbo.PrivacyFlagTypes");
            DropIndex("dbo.PrivacyFlags", new[] { "VisibilityId" });
            DropIndex("dbo.PrivacyFlags", new[] { "ProfileId" });
            DropIndex("dbo.PrivacyFlags", new[] { "PrivacyFlagTypeId" });
            DropTable("dbo.Visibilities");
            DropTable("dbo.PrivacyFlagTypes");
            DropTable("dbo.PrivacyFlags");
        }
    }
}
