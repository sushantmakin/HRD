namespace HitaRasDhara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class statusInQuery : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QueryViewModels", "Status", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.QueryViewModels", "Status");
        }
    }
}
