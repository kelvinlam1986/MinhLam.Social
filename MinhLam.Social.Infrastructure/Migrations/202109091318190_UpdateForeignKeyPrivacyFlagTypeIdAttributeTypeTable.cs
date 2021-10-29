namespace MinhLam.Social.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateForeignKeyPrivacyFlagTypeIdAttributeTypeTable : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ProfileAttributeTypes", "PrivacyFlagTypeId");
            AddForeignKey("dbo.ProfileAttributeTypes", "PrivacyFlagTypeId", "dbo.PrivacyFlagTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProfileAttributeTypes", "PrivacyFlagTypeId", "dbo.PrivacyFlagTypes");
            DropIndex("dbo.ProfileAttributeTypes", new[] { "PrivacyFlagTypeId" });
        }
    }
}
