namespace LetsJam.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class startdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enrollment", "StudentName", c => c.String());
            AddColumn("dbo.Enrollment", "Instrument", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Enrollment", "Instrument");
            DropColumn("dbo.Enrollment", "StudentName");
        }
    }
}
