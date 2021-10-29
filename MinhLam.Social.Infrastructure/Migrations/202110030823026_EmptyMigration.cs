namespace MinhLam.Social.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmptyMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "Avatar", c => c.Binary());
            AddColumn("dbo.Profiles", "AvatarMimeType", c => c.String());
            AddColumn("dbo.Profiles", "UseGravatar", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Profiles", "UseGravatar");
            DropColumn("dbo.Profiles", "AvatarMimeType");
            DropColumn("dbo.Profiles", "Avatar");
        }
    }
}
