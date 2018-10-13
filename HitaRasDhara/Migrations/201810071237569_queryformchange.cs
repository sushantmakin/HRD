namespace HitaRasDhara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class queryformchange : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.QueryViewModels", "QueryId");
            DropColumn("dbo.QueryViewModels", "PhoneCountryCode");
            DropColumn("dbo.QueryViewModels", "State");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QueryViewModels", "State", c => c.String(nullable: false));
            AddColumn("dbo.QueryViewModels", "PhoneCountryCode", c => c.String(nullable: false));
            AddColumn("dbo.QueryViewModels", "QueryId", c => c.String());
        }
    }
}
