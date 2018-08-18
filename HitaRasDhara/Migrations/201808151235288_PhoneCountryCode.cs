namespace HitaRasDhara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhoneCountryCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QueryViewModels", "PhoneCountryCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.QueryViewModels", "PhoneCountryCode");
        }
    }
}
