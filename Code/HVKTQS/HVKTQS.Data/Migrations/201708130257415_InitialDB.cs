namespace HVKTQS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false, maxLength: 255),
                        Description = c.String(),
                        ViewOrder = c.Int(),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 50),
                        DateOfBirth = c.DateTime(),
                        Sex = c.Boolean(),
                        Address = c.String(maxLength: 255),
                        Email = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 30),
                        PositionID = c.Int(),
                        SubjectID = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Position", t => t.PositionID)
                .ForeignKey("dbo.Subject", t => t.SubjectID)
                .ForeignKey("dbo.User", t => t.EmployeeID)
                .Index(t => t.EmployeeID)
                .Index(t => t.PositionID)
                .Index(t => t.SubjectID);
            
            CreateTable(
                "dbo.Position",
                c => new
                    {
                        PositionID = c.Int(nullable: false, identity: true),
                        PositionName = c.String(nullable: false, maxLength: 255),
                        ViewOrder = c.Int(),
                    })
                .PrimaryKey(t => t.PositionID);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(nullable: false, maxLength: 255),
                        DepartmentID = c.Int(),
                        Description = c.String(),
                        ViewOrder = c.Int(),
                    })
                .PrimaryKey(t => t.SubjectID)
                .ForeignKey("dbo.Department", t => t.DepartmentID)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        LastIPAddress = c.String(maxLength: 10),
                        IsLock = c.Boolean(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.EventFile",
                c => new
                    {
                        EventFileID = c.Int(nullable: false, identity: true),
                        EventID = c.Int(nullable: false),
                        FileName = c.String(nullable: false, maxLength: 255),
                        FileSize = c.Long(),
                        FilePath = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.EventFileID)
                .ForeignKey("dbo.Event", t => t.EventID, cascadeDelete: true)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        OriginalEventId = c.Int(),
                        Title = c.String(nullable: false, maxLength: 255),
                        Description = c.String(),
                        Location = c.String(maxLength: 255),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        IsImportant = c.Boolean(),
                        IsDone = c.Boolean(),
                        SubjectID = c.Int(),
                        DepartmentID = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 255),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.Department", t => t.DepartmentID)
                .ForeignKey("dbo.Subject", t => t.SubjectID)
                .Index(t => t.SubjectID)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.EventNote",
                c => new
                    {
                        NoteId = c.Int(nullable: false, identity: true),
                        EventID = c.Int(),
                        Content = c.String(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 255),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.NoteId)
                .ForeignKey("dbo.Event", t => t.EventID)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.EventUser",
                c => new
                    {
                        EventID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Status = c.Int(),
                        ActionDate = c.DateTime(nullable: false),
                        ReadDate = c.DateTime(nullable: false),
                        IsPermissonModify = c.Boolean(),
                        IsRead = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.EventID, t.UserID })
                .ForeignKey("dbo.Event", t => t.EventID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.EventID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventUser", "UserID", "dbo.User");
            DropForeignKey("dbo.EventUser", "EventID", "dbo.Event");
            DropForeignKey("dbo.EventNote", "EventID", "dbo.Event");
            DropForeignKey("dbo.EventFile", "EventID", "dbo.Event");
            DropForeignKey("dbo.Event", "SubjectID", "dbo.Subject");
            DropForeignKey("dbo.Event", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Employee", "EmployeeID", "dbo.User");
            DropForeignKey("dbo.Employee", "SubjectID", "dbo.Subject");
            DropForeignKey("dbo.Subject", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Employee", "PositionID", "dbo.Position");
            DropIndex("dbo.EventUser", new[] { "UserID" });
            DropIndex("dbo.EventUser", new[] { "EventID" });
            DropIndex("dbo.EventNote", new[] { "EventID" });
            DropIndex("dbo.Event", new[] { "DepartmentID" });
            DropIndex("dbo.Event", new[] { "SubjectID" });
            DropIndex("dbo.EventFile", new[] { "EventID" });
            DropIndex("dbo.Subject", new[] { "DepartmentID" });
            DropIndex("dbo.Employee", new[] { "SubjectID" });
            DropIndex("dbo.Employee", new[] { "PositionID" });
            DropIndex("dbo.Employee", new[] { "EmployeeID" });
            DropTable("dbo.EventUser");
            DropTable("dbo.EventNote");
            DropTable("dbo.Event");
            DropTable("dbo.EventFile");
            DropTable("dbo.User");
            DropTable("dbo.Subject");
            DropTable("dbo.Position");
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
        }
    }
}
