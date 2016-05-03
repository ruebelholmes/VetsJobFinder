namespace VetsJobFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityModelsClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "EmailAddress", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "EmailAddress");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "UserId");
        }
    }
}
