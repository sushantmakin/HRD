namespace HitaRasDhara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class timestamp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserResponse5Aug", "TimeStamp", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserResponse5Aug", "TimeStamp");
        }
    }
}
