namespace StackOverflow_Clone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTagRefToQuestion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TagName = c.String(),
                        question_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.question_Id)
                .Index(t => t.question_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "question_Id", "dbo.Questions");
            DropIndex("dbo.Tags", new[] { "question_Id" });
            DropTable("dbo.Tags");
        }
    }
}
