namespace HitaRasDhara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class query : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QueryViewModels",
                c => new
                    {
                        QueryId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        Query = c.String(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.QueryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.QueryViewModels");
        }
    }
}
