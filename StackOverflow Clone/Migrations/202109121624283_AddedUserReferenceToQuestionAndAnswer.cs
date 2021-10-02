namespace StackOverflow_Clone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserReferenceToQuestionAndAnswer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "User_Id", c => c.Int());
            AddColumn("dbo.Questions", "User_Id", c => c.Int());
            CreateIndex("dbo.Answers", "User_Id");
            CreateIndex("dbo.Questions", "User_Id");
            AddForeignKey("dbo.Answers", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Questions", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Answers", "User_Id", "dbo.Users");
            DropIndex("dbo.Questions", new[] { "User_Id" });
            DropIndex("dbo.Answers", new[] { "User_Id" });
            DropColumn("dbo.Questions", "User_Id");
            DropColumn("dbo.Answers", "User_Id");
        }
    }
}
