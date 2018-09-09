namespace HitaRasDhara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stateinQuery : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QueryViewModels", "State", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.QueryViewModels", "State");
        }
    }
}
