namespace LetsJam.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enrollment",
                c => new
                    {
                        MemberId = c.Int(nullable: false),
                        LessonId = c.Int(nullable: false),
                        DifficultyLevel = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.MemberId, t.LessonId })
                .ForeignKey("dbo.Lesson", t => t.LessonId, cascadeDelete: true)
                .ForeignKey("dbo.Member", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.LessonId);
            
            CreateTable(
                "dbo.Lesson",
                c => new
                    {
                        LessonId = c.Int(nullable: false, identity: true),
                        Instrument = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LessonId);
            
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(),
                        Phone = c.String(),
                        IsStudent = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MemberId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        SKU = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NumberInStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SKU);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        SKU = c.String(maxLength: 128),
                        MemberId = c.Int(nullable: false),
                        DateOfTransaction = c.DateTime(nullable: false),
                        NumberOfProductPurchased = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Member", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.SKU)
                .Index(t => t.SKU)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ProductMember",
                c => new
                    {
                        Product_SKU = c.String(nullable: false, maxLength: 128),
                        Member_MemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_SKU, t.Member_MemberId })
                .ForeignKey("dbo.Product", t => t.Product_SKU, cascadeDelete: true)
                .ForeignKey("dbo.Member", t => t.Member_MemberId, cascadeDelete: true)
                .Index(t => t.Product_SKU)
                .Index(t => t.Member_MemberId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Transaction", "SKU", "dbo.Product");
            DropForeignKey("dbo.Transaction", "MemberId", "dbo.Member");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Enrollment", "MemberId", "dbo.Member");
            DropForeignKey("dbo.ProductMember", "Member_MemberId", "dbo.Member");
            DropForeignKey("dbo.ProductMember", "Product_SKU", "dbo.Product");
            DropForeignKey("dbo.Enrollment", "LessonId", "dbo.Lesson");
            DropIndex("dbo.ProductMember", new[] { "Member_MemberId" });
            DropIndex("dbo.ProductMember", new[] { "Product_SKU" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Transaction", new[] { "MemberId" });
            DropIndex("dbo.Transaction", new[] { "SKU" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Enrollment", new[] { "LessonId" });
            DropIndex("dbo.Enrollment", new[] { "MemberId" });
            DropTable("dbo.ProductMember");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Transaction");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Product");
            DropTable("dbo.Member");
            DropTable("dbo.Lesson");
            DropTable("dbo.Enrollment");
        }
    }
}
