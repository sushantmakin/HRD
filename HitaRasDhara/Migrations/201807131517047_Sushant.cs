namespace HitaRasDhara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sushant : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DatabaseModels", newName: "UserResponse5Aug");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.UserResponse5Aug", newName: "DatabaseModels");
        }
    }
}
