namespace StackOverflow_Clone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAppUserToQAA : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "Appuser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Questions", "Appuser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Answers", "Appuser_Id");
            CreateIndex("dbo.Questions", "Appuser_Id");
            AddForeignKey("dbo.Answers", "Appuser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Questions", "Appuser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "Appuser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Answers", "Appuser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Questions", new[] { "Appuser_Id" });
            DropIndex("dbo.Answers", new[] { "Appuser_Id" });
            DropColumn("dbo.Questions", "Appuser_Id");
            DropColumn("dbo.Answers", "Appuser_Id");
        }
    }
}
