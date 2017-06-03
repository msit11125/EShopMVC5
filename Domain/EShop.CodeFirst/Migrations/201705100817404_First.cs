namespace EShop.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100),
                        PhoneNumber = c.String(nullable: false, maxLength: 50),
                        Photo = c.String(maxLength: 50),
                        Description = c.String(maxLength: 500),
                        Cash = c.Decimal(nullable: false, precision: 9, scale: 2),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        RecievedAddress = c.String(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        ShipDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Account", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        OrderDetailID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Qunatity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 9, scale: 2),
                    })
                .PrimaryKey(t => t.OrderDetailID)
                .ForeignKey("dbo.Order", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductModel = c.String(nullable: false, maxLength: 50),
                        ProductName = c.String(nullable: false, maxLength: 50),
                        CategorySubID = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 9, scale: 2),
                        Photo = c.String(),
                        Description = c.String(),
                        Status = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.CategorySub", t => t.CategorySubID, cascadeDelete: true)
                .Index(t => t.CategorySubID);
            
            CreateTable(
                "dbo.CategorySub",
                c => new
                    {
                        CategorySubID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        CategoryNameSub = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.CategorySubID)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.ShoppingCart",
                c => new
                    {
                        RecordID = c.Int(nullable: false, identity: true),
                        CartID = c.String(maxLength: 50),
                        ProductID = c.Int(nullable: false),
                        Qunatity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 9, scale: 2),
                    })
                .PrimaryKey(t => t.RecordID)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetail", "ProductID", "dbo.Product");
            DropForeignKey("dbo.ShoppingCart", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Product", "CategorySubID", "dbo.CategorySub");
            DropForeignKey("dbo.CategorySub", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.OrderDetail", "OrderID", "dbo.Order");
            DropForeignKey("dbo.Order", "UserID", "dbo.Account");
            DropIndex("dbo.ShoppingCart", new[] { "ProductID" });
            DropIndex("dbo.CategorySub", new[] { "CategoryID" });
            DropIndex("dbo.Product", new[] { "CategorySubID" });
            DropIndex("dbo.OrderDetail", new[] { "ProductID" });
            DropIndex("dbo.OrderDetail", new[] { "OrderID" });
            DropIndex("dbo.Order", new[] { "UserID" });
            DropTable("dbo.ShoppingCart");
            DropTable("dbo.Category");
            DropTable("dbo.CategorySub");
            DropTable("dbo.Product");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.Order");
            DropTable("dbo.Account");
        }
    }
}
