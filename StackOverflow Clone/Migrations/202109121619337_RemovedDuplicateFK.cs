namespace StackOverflow_Clone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedDuplicateFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "CategoryId_Id", "dbo.Categories");
            DropForeignKey("dbo.Answers", "QuestionId_Id", "dbo.Questions");
            DropForeignKey("dbo.Answers", "Questions_Id", "dbo.Questions");
            DropIndex("dbo.Answers", new[] { "QuestionId_Id" });
            DropIndex("dbo.Answers", new[] { "Questions_Id" });
            DropIndex("dbo.Questions", new[] { "CategoryId_Id" });
            DropColumn("dbo.Answers", "QuestionId_Id");
            DropColumn("dbo.Answers", "Questions_Id");
            DropColumn("dbo.Questions", "CategoryId_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "CategoryId_Id", c => c.Int());
            AddColumn("dbo.Answers", "Questions_Id", c => c.Int());
            AddColumn("dbo.Answers", "QuestionId_Id", c => c.Int());
            CreateIndex("dbo.Questions", "CategoryId_Id");
            CreateIndex("dbo.Answers", "Questions_Id");
            CreateIndex("dbo.Answers", "QuestionId_Id");
            AddForeignKey("dbo.Answers", "Questions_Id", "dbo.Questions", "Id");
            AddForeignKey("dbo.Answers", "QuestionId_Id", "dbo.Questions", "Id");
            AddForeignKey("dbo.Questions", "CategoryId_Id", "dbo.Categories", "Id");
        }
    }
}
