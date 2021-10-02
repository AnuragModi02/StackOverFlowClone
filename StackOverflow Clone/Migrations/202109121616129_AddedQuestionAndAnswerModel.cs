namespace StackOverflow_Clone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedQuestionAndAnswerModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Answers = c.String(),
                        Question_Id = c.Int(),
                        QuestionId_Id = c.Int(),
                        Questions_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.Question_Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId_Id)
                .ForeignKey("dbo.Questions", t => t.Questions_Id)
                .Index(t => t.Question_Id)
                .Index(t => t.QuestionId_Id)
                .Index(t => t.Questions_Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Questions = c.String(),
                        Category_Id = c.Int(),
                        CategoryId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.CategoryId_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "Questions_Id", "dbo.Questions");
            DropForeignKey("dbo.Answers", "QuestionId_Id", "dbo.Questions");
            DropForeignKey("dbo.Questions", "CategoryId_Id", "dbo.Categories");
            DropForeignKey("dbo.Questions", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Answers", "Question_Id", "dbo.Questions");
            DropIndex("dbo.Questions", new[] { "CategoryId_Id" });
            DropIndex("dbo.Questions", new[] { "Category_Id" });
            DropIndex("dbo.Answers", new[] { "Questions_Id" });
            DropIndex("dbo.Answers", new[] { "QuestionId_Id" });
            DropIndex("dbo.Answers", new[] { "Question_Id" });
            DropTable("dbo.Categories");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
