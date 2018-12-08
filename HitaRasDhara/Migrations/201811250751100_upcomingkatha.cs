namespace HitaRasDhara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upcomingkatha : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UpcomingKathaItems",
                c => new
                    {
                        KathaId = c.Int(nullable: false, identity: true),
                        KathaTitle = c.String(nullable: false),
                        Dates = c.String(nullable: false),
                        Timings = c.String(nullable: false),
                        AddressLine1 = c.String(nullable: false),
                        AddressLine2 = c.String(nullable: false),
                        AddressLine3 = c.String(nullable: false),
                        LocationUrl = c.String(nullable: false),
                        GoogleCalenderUrl = c.String(nullable: false),
                        ImageUrl = c.String(nullable: false),
                        UnpublishDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.KathaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UpcomingKathaItems");
        }
    }
}
