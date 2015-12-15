namespace Graphics4Teachers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class School : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "School", c => c.String());
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Name");
            DropColumn("dbo.AspNetUsers", "School");
        }
    }
}
