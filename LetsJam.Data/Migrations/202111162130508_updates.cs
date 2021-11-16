namespace LetsJam.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updates : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductMember", "Product_SKU", "dbo.Product");
            DropForeignKey("dbo.ProductMember", "Member_MemberId", "dbo.Member");
            DropIndex("dbo.ProductMember", new[] { "Product_SKU" });
            DropIndex("dbo.ProductMember", new[] { "Member_MemberId" });
            DropTable("dbo.ProductMember");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductMember",
                c => new
                    {
                        Product_SKU = c.String(nullable: false, maxLength: 128),
                        Member_MemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_SKU, t.Member_MemberId });
            
            CreateIndex("dbo.ProductMember", "Member_MemberId");
            CreateIndex("dbo.ProductMember", "Product_SKU");
            AddForeignKey("dbo.ProductMember", "Member_MemberId", "dbo.Member", "MemberId", cascadeDelete: true);
            AddForeignKey("dbo.ProductMember", "Product_SKU", "dbo.Product", "SKU", cascadeDelete: true);
        }
    }
}
