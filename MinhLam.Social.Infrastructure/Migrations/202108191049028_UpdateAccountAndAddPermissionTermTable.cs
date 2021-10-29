namespace MinhLam.Social.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAccountAndAddPermissionTermTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Terms",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Terms = c.String(nullable: false, maxLength: 500),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AccountPermissions",
                c => new
                    {
                        AccountId = c.Guid(nullable: false),
                        PermissionId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.AccountId, t.PermissionId })
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.Permissions", t => t.PermissionId, cascadeDelete: true)
                .Index(t => t.AccountId)
                .Index(t => t.PermissionId);
            
            AddColumn("dbo.Accounts", "FirstName", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Accounts", "LastName", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Accounts", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Accounts", "ZipCode", c => c.String(nullable: false, maxLength: 15));
            AddColumn("dbo.Accounts", "TermId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Accounts", "Username", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Accounts", "Password", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Accounts", "Email", c => c.String(nullable: false, maxLength: 150));
            CreateIndex("dbo.Accounts", "TermId");
            AddForeignKey("dbo.Accounts", "TermId", "dbo.Terms", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountPermissions", "PermissionId", "dbo.Permissions");
            DropForeignKey("dbo.AccountPermissions", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "TermId", "dbo.Terms");
            DropIndex("dbo.AccountPermissions", new[] { "PermissionId" });
            DropIndex("dbo.AccountPermissions", new[] { "AccountId" });
            DropIndex("dbo.Accounts", new[] { "TermId" });
            AlterColumn("dbo.Accounts", "Email", c => c.String());
            AlterColumn("dbo.Accounts", "Password", c => c.String());
            AlterColumn("dbo.Accounts", "Username", c => c.String());
            DropColumn("dbo.Accounts", "TermId");
            DropColumn("dbo.Accounts", "ZipCode");
            DropColumn("dbo.Accounts", "BirthDate");
            DropColumn("dbo.Accounts", "LastName");
            DropColumn("dbo.Accounts", "FirstName");
            DropTable("dbo.AccountPermissions");
            DropTable("dbo.Permissions");
            DropTable("dbo.Terms");
        }
    }
}
