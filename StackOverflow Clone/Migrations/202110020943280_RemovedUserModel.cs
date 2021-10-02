namespace StackOverflow_Clone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedUserModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Answers", "User_Id", "dbo.Users");
            DropIndex("dbo.Answers", new[] { "User_Id" });
            DropIndex("dbo.Questions", new[] { "User_Id" });
            DropColumn("dbo.Answers", "User_Id");
            DropColumn("dbo.Questions", "User_Id");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Questions", "User_Id", c => c.Int());
            AddColumn("dbo.Answers", "User_Id", c => c.Int());
            CreateIndex("dbo.Questions", "User_Id");
            CreateIndex("dbo.Answers", "User_Id");
            AddForeignKey("dbo.Answers", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Questions", "User_Id", "dbo.Users", "Id");
        }
    }
}
