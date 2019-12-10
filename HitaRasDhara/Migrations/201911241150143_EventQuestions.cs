namespace HitaRasDhara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventQuestions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestionsViewModels",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Question = c.String(nullable: false),
                        ListenedAt = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.QuestionsViewModels");
        }
    }
}
