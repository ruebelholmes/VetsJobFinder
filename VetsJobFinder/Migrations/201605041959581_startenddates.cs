namespace VetsJobFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class startenddates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "StartApplicationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Jobs", "EndApplicationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "EndApplicationDate");
            DropColumn("dbo.Jobs", "StartApplicationDate");
        }
    }
}
