namespace HitaRasDhara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ID : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.QueryViewModels");
            AddColumn("dbo.QueryViewModels", "RegistrationID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.QueryViewModels", "QueryId", c => c.String());
            AddPrimaryKey("dbo.QueryViewModels", "RegistrationID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.QueryViewModels");
            AlterColumn("dbo.QueryViewModels", "QueryId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.QueryViewModels", "RegistrationID");
            AddPrimaryKey("dbo.QueryViewModels", "QueryId");
        }
    }
}
