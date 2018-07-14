namespace PRSserver.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingmodelsandcontrollers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VendorId = c.Int(nullable: false),
                        PartNumber = c.String(),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unit = c.String(),
                        PhotoPath = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vendors", t => t.VendorId, cascadeDelete: true)
                .Index(t => t.VendorId);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Preapproved = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PurchaseRequestLineItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseRequestId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ProductUnit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.PurchaseRequests", t => t.PurchaseRequestId, cascadeDelete: true)
                .Index(t => t.PurchaseRequestId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.PurchaseRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RequestDescription = c.String(),
                        RequestJustification = c.String(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.String(),
                        DeliveryMode = c.String(),
                        Active = c.Boolean(nullable: false),
                        ReasonForRejection = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Reviewer = c.Boolean(nullable: false),
                        Admin = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseRequestLineItems", "PurchaseRequestId", "dbo.PurchaseRequests");
            DropForeignKey("dbo.PurchaseRequests", "UserId", "dbo.Users");
            DropForeignKey("dbo.PurchaseRequestLineItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "VendorId", "dbo.Vendors");
            DropIndex("dbo.PurchaseRequests", new[] { "UserId" });
            DropIndex("dbo.PurchaseRequestLineItems", new[] { "ProductId" });
            DropIndex("dbo.PurchaseRequestLineItems", new[] { "PurchaseRequestId" });
            DropIndex("dbo.Products", new[] { "VendorId" });
            DropTable("dbo.Users");
            DropTable("dbo.PurchaseRequests");
            DropTable("dbo.PurchaseRequestLineItems");
            DropTable("dbo.Vendors");
            DropTable("dbo.Products");
        }
    }
}
