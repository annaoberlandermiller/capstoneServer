namespace PRSserver.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedpurchaserequestandpurchaserequestlineitemsclasses : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PurchaseRequests", "RequestDescription", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.PurchaseRequests", "RequestJustification", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.PurchaseRequests", "Status", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.PurchaseRequests", "DeliveryMode", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.PurchaseRequests", "ReasonForRejection", c => c.String(maxLength: 80));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PurchaseRequests", "ReasonForRejection", c => c.String());
            AlterColumn("dbo.PurchaseRequests", "DeliveryMode", c => c.String());
            AlterColumn("dbo.PurchaseRequests", "Status", c => c.String());
            AlterColumn("dbo.PurchaseRequests", "RequestJustification", c => c.String());
            AlterColumn("dbo.PurchaseRequests", "RequestDescription", c => c.String());
        }
    }
}
