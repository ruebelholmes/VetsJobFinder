namespace VetsJobFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeControlAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employers",
                c => new
                    {
                        EmployerId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false),
                        EmployerEmail = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmployerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employers");
        }
    }
}
