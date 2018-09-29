namespace HitaRasDhara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newKeyQuery : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.QueryViewModels");
            AddColumn("dbo.QueryViewModels", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.QueryViewModels", "QueryId", c => c.String());
            AddPrimaryKey("dbo.QueryViewModels", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.QueryViewModels");
            AlterColumn("dbo.QueryViewModels", "QueryId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.QueryViewModels", "ID");
            AddPrimaryKey("dbo.QueryViewModels", "QueryId");
        }
    }
}
