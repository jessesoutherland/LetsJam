namespace LetsJam.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transaction", "SKU", "dbo.Product");
            DropIndex("dbo.Transaction", new[] { "SKU" });
            AlterColumn("dbo.Transaction", "SKU", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Transaction", "DateOfTransaction", c => c.DateTimeOffset(nullable: false, precision: 7));
            CreateIndex("dbo.Transaction", "SKU");
            AddForeignKey("dbo.Transaction", "SKU", "dbo.Product", "SKU", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction", "SKU", "dbo.Product");
            DropIndex("dbo.Transaction", new[] { "SKU" });
            AlterColumn("dbo.Transaction", "DateOfTransaction", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Transaction", "SKU", c => c.String(maxLength: 128));
            CreateIndex("dbo.Transaction", "SKU");
            AddForeignKey("dbo.Transaction", "SKU", "dbo.Product", "SKU");
        }
    }
}
