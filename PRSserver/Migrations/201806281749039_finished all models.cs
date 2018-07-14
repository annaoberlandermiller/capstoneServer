namespace PRSserver.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finishedallmodels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "PartNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Products", "Unit", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Vendors", "Code", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.Vendors", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Vendors", "Address", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Vendors", "City", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Vendors", "State", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.Vendors", "Zip", c => c.String(nullable: false));
            AlterColumn("dbo.Vendors", "Phone", c => c.String(nullable: false, maxLength: 12));
            AlterColumn("dbo.Vendors", "Email", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "Phone", c => c.String(nullable: false, maxLength: 12));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 80));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "Phone", c => c.String());
            AlterColumn("dbo.Users", "LastName", c => c.String());
            AlterColumn("dbo.Users", "FirstName", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Username", c => c.String());
            AlterColumn("dbo.Vendors", "Email", c => c.String());
            AlterColumn("dbo.Vendors", "Phone", c => c.String());
            AlterColumn("dbo.Vendors", "Zip", c => c.String());
            AlterColumn("dbo.Vendors", "State", c => c.String());
            AlterColumn("dbo.Vendors", "City", c => c.String());
            AlterColumn("dbo.Vendors", "Address", c => c.String());
            AlterColumn("dbo.Vendors", "Name", c => c.String());
            AlterColumn("dbo.Vendors", "Code", c => c.String());
            AlterColumn("dbo.Products", "Unit", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.Products", "PartNumber", c => c.String());
        }
    }
}
