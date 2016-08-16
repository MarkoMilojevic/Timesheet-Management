namespace TimesheetManagement.Data.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        TaxpayerIdentificationNumber = c.String(nullable: false, maxLength: 9),
                        Name = c.String(nullable: false, maxLength: 50),
                        RegisterNumber = c.String(nullable: false, maxLength: 8),
                    })
                .PrimaryKey(t => t.TaxpayerIdentificationNumber);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        TaxpayerIdentificationNumber = c.String(maxLength: 9),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Account", t => t.TaxpayerIdentificationNumber)
                .Index(t => t.TaxpayerIdentificationNumber);
            
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        AccountId = c.String(maxLength: 9),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.Account", t => t.AccountId)
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.AccountId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Activity",
                c => new
                    {
                        ActivityId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        DurationInHours = c.Int(nullable: false),
                        Description = c.String(maxLength: 500),
                        IsApproved = c.Boolean(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ActivityId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 80),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.TaskActivity",
                c => new
                    {
                        TaskId = c.Int(nullable: false),
                        ActivityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TaskId, t.ActivityId })
                .ForeignKey("dbo.Activity", t => t.ActivityId, cascadeDelete: true)
                .ForeignKey("dbo.Task", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.TaskId)
                .Index(t => t.ActivityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskActivity", "TaskId", "dbo.Task");
            DropForeignKey("dbo.TaskActivity", "ActivityId", "dbo.Activity");
            DropForeignKey("dbo.Activity", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Task", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.Task", "AccountId", "dbo.Account");
            DropForeignKey("dbo.Project", "TaxpayerIdentificationNumber", "dbo.Account");
            DropIndex("dbo.TaskActivity", new[] { "ActivityId" });
            DropIndex("dbo.TaskActivity", new[] { "TaskId" });
            DropIndex("dbo.Employee", new[] { "Email" });
            DropIndex("dbo.Activity", new[] { "EmployeeId" });
            DropIndex("dbo.Task", new[] { "ProjectId" });
            DropIndex("dbo.Task", new[] { "AccountId" });
            DropIndex("dbo.Project", new[] { "TaxpayerIdentificationNumber" });
            DropTable("dbo.TaskActivity");
            DropTable("dbo.Employee");
            DropTable("dbo.Activity");
            DropTable("dbo.Task");
            DropTable("dbo.Project");
            DropTable("dbo.Account");
        }
    }
}
