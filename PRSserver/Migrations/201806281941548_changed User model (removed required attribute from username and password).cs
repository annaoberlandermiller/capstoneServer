namespace PRSserver.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedUsermodelremovedrequiredattributefromusernameandpassword : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Username", c => c.String(maxLength: 30));
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
