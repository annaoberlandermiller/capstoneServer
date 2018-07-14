namespace PRSserver.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedpropertyfromPurchaseRequestLineItemsmodel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PurchaseRequestLineItems", "ProductUnit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PurchaseRequestLineItems", "ProductUnit", c => c.Int(nullable: false));
        }
    }
}
