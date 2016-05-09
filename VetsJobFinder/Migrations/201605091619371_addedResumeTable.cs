namespace VetsJobFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedResumeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Resumes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        PostedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Resumes");
        }
    }
}
