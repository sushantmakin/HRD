namespace HitaRasDhara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserResponse5Aug");
            AlterColumn("dbo.UserResponse5Aug", "Phone", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.UserResponse5Aug", "Phone");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserResponse5Aug");
            AlterColumn("dbo.UserResponse5Aug", "Phone", c => c.String(nullable: false));
            AddPrimaryKey("dbo.UserResponse5Aug", "RegistrationID");
        }
    }
}
