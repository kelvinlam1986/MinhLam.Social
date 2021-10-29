namespace MinhLam.Social.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreatedDateModifiedDateToAccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Accounts", "LastUpdated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "LastUpdated");
            DropColumn("dbo.Accounts", "CreatedDate");
        }
    }
}
