namespace HitaRasDhara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SadhakSanjeevani : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SadhakSanjeevaniItems",
                c => new
                    {
                        VideoId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        ThumbnailUrl = c.String(nullable: false),
                        YoutubeLink = c.String(nullable: false),
                        VisibleOnHome = c.Boolean(nullable: false),
                        VisibleOnInsidePage = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.VideoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SadhakSanjeevaniItems");
        }
    }
}
