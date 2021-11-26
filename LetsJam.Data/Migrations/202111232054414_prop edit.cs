namespace LetsJam.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class propedit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enrollment", "StartDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Lesson", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lesson", "Description", c => c.String(nullable: false));
            DropColumn("dbo.Enrollment", "StartDate");
        }
    }
}
