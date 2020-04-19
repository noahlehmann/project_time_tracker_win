namespace ProjectTimeTrackerWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        Description = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        Value = c.String(),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Project_Id);
            
            CreateTable(
                "dbo.ProjectTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Project_Id = c.Int(),
                        WorkDay_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .ForeignKey("dbo.WorkDays", t => t.WorkDay_Id)
                .Index(t => t.Project_Id)
                .Index(t => t.WorkDay_Id);
            
            CreateTable(
                "dbo.WorkDays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectTimes", "WorkDay_Id", "dbo.WorkDays");
            DropForeignKey("dbo.ProjectTimes", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.ProjectProperties", "Project_Id", "dbo.Projects");
            DropIndex("dbo.ProjectTimes", new[] { "WorkDay_Id" });
            DropIndex("dbo.ProjectTimes", new[] { "Project_Id" });
            DropIndex("dbo.ProjectProperties", new[] { "Project_Id" });
            DropTable("dbo.WorkDays");
            DropTable("dbo.ProjectTimes");
            DropTable("dbo.ProjectProperties");
            DropTable("dbo.Projects");
        }
    }
}
