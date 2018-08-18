namespace HitaRasDhara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Feedback : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventFeedbackViewModels",
                c => new
                    {
                        Phone = c.String(nullable: false, maxLength: 128),
                        Feedback = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Phone);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EventFeedbackViewModels");
        }
    }
}
