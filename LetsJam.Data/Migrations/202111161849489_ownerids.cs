namespace LetsJam.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ownerids : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enrollment", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Lesson", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Member", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Product", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Transaction", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transaction", "OwnerId");
            DropColumn("dbo.Product", "OwnerId");
            DropColumn("dbo.Member", "OwnerId");
            DropColumn("dbo.Lesson", "OwnerId");
            DropColumn("dbo.Enrollment", "OwnerId");
        }
    }
}
