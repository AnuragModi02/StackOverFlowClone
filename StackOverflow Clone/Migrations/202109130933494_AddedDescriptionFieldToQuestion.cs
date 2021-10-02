namespace StackOverflow_Clone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDescriptionFieldToQuestion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "Description");
        }
    }
}
