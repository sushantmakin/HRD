namespace HitaRasDhara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResponseInDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QueryViewModels", "Response", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.QueryViewModels", "Response");
        }
    }
}
