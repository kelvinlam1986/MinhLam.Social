namespace MinhLam.Social.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPrivacyFlagTypeToProfileAttributeTypeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProfileAttributeTypes", "PrivacyFlagTypeId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProfileAttributeTypes", "PrivacyFlagTypeId");
        }
    }
}
