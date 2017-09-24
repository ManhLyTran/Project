namespace HVKTQS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changekey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUsers", "EmployeeID", c => c.Int(nullable: false));
            DropColumn("dbo.ApplicationUsers", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUsers", "UserID", c => c.Int(nullable: false));
            DropColumn("dbo.ApplicationUsers", "EmployeeID");
        }
    }
}
