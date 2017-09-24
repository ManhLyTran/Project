namespace HVKTQS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntergrateAspIdentity : DbMigration
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
                        Users_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Position", t => t.PositionID)
                .ForeignKey("dbo.Subject", t => t.SubjectID)
                .ForeignKey("dbo.ApplicationUsers", t => t.Users_Id)
                .Index(t => t.PositionID)
                .Index(t => t.SubjectID)
                .Index(t => t.Users_Id);
            
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
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserID = c.Int(nullable: false),
                        FullName = c.String(maxLength: 255),
                        Address = c.String(maxLength: 255),
                        BirthDay = c.DateTime(),
                        LastIPAddress = c.String(),
                        IsLock = c.Boolean(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationUserClaims",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.ApplicationRoles", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.Error",
                c => new
                    {
                        ErrorID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        StackTrace = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ErrorID);
            
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
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.EventID, t.UserID })
                .ForeignKey("dbo.Event", t => t.EventID, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUsers", t => t.User_Id)
                .Index(t => t.EventID)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.ApplicationRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserRoles", "IdentityRole_Id", "dbo.ApplicationRoles");
            DropForeignKey("dbo.EventUser", "User_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.EventUser", "EventID", "dbo.Event");
            DropForeignKey("dbo.EventNote", "EventID", "dbo.Event");
            DropForeignKey("dbo.EventFile", "EventID", "dbo.Event");
            DropForeignKey("dbo.Event", "SubjectID", "dbo.Subject");
            DropForeignKey("dbo.Event", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Employee", "Users_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.ApplicationUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.ApplicationUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.ApplicationUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Employee", "SubjectID", "dbo.Subject");
            DropForeignKey("dbo.Subject", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Employee", "PositionID", "dbo.Position");
            DropIndex("dbo.EventUser", new[] { "User_Id" });
            DropIndex("dbo.EventUser", new[] { "EventID" });
            DropIndex("dbo.EventNote", new[] { "EventID" });
            DropIndex("dbo.Event", new[] { "DepartmentID" });
            DropIndex("dbo.Event", new[] { "SubjectID" });
            DropIndex("dbo.EventFile", new[] { "EventID" });
            DropIndex("dbo.ApplicationUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.ApplicationUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Subject", new[] { "DepartmentID" });
            DropIndex("dbo.Employee", new[] { "Users_Id" });
            DropIndex("dbo.Employee", new[] { "SubjectID" });
            DropIndex("dbo.Employee", new[] { "PositionID" });
            DropTable("dbo.ApplicationRoles");
            DropTable("dbo.EventUser");
            DropTable("dbo.EventNote");
            DropTable("dbo.Event");
            DropTable("dbo.EventFile");
            DropTable("dbo.Error");
            DropTable("dbo.ApplicationUserRoles");
            DropTable("dbo.ApplicationUserLogins");
            DropTable("dbo.ApplicationUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.Subject");
            DropTable("dbo.Position");
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
        }
    }
}
