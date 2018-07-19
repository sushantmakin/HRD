namespace HitaRasDhara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yearofbirth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserResponse5Aug", "YearOfBirth", c => c.String(nullable: false));
            DropColumn("dbo.UserResponse5Aug", "DateOfBirth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserResponse5Aug", "DateOfBirth", c => c.DateTime(nullable: false));
            DropColumn("dbo.UserResponse5Aug", "YearOfBirth");
        }
    }
}
