namespace KamilCieślikLab4PD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuProducts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Category = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        AmountOfCalories = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Order_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Orders", t => t.Order_ID)
                .Index(t => t.Order_ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        SellerID = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        YearsOfExperience = c.Int(nullable: false),
                        EnglishLevel = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Localization = c.String(nullable: false),
                        DeliveryTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Supplies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        OrderedProduct = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        ProviderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuProducts", "Order_ID", "dbo.Orders");
            DropIndex("dbo.MenuProducts", new[] { "Order_ID" });
            DropTable("dbo.Supplies");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Sellers");
            DropTable("dbo.Orders");
            DropTable("dbo.MenuProducts");
        }
    }
}
