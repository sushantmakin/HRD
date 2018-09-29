namespace HitaRasDhara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.QueryViewModels");
            DropPrimaryKey("dbo.UserResponse5Aug");
            AddColumn("dbo.UserResponse5Aug", "RegistrationID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.QueryViewModels", "QueryId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserResponse5Aug", "Phone", c => c.String(nullable: false));
            AddPrimaryKey("dbo.QueryViewModels", "QueryId");
            AddPrimaryKey("dbo.UserResponse5Aug", "RegistrationID");
            DropColumn("dbo.QueryViewModels", "RegistrationID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QueryViewModels", "RegistrationID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.UserResponse5Aug");
            DropPrimaryKey("dbo.QueryViewModels");
            AlterColumn("dbo.UserResponse5Aug", "Phone", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.QueryViewModels", "QueryId", c => c.String());
            DropColumn("dbo.UserResponse5Aug", "RegistrationID");
            AddPrimaryKey("dbo.UserResponse5Aug", "Phone");
            AddPrimaryKey("dbo.QueryViewModels", "RegistrationID");
        }
    }
}
