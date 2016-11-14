using System.Data.Entity.Migrations;

namespace TimesheetManagement.Data.EntityFramework.Migrations
{
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                {
                    TaxpayerIdentificationNumber = c.String(false, 9),
                    Name = c.String(false, 50),
                    RegisterNumber = c.String(false, 8)
                })
                .PrimaryKey(t => t.TaxpayerIdentificationNumber);

            CreateTable(
                "dbo.Project",
                c => new
                {
                    ProjectId = c.Int(false, true),
                    Name = c.String(false, 50),
                    StartDate = c.DateTime(false),
                    EndDate = c.DateTime(false),
                    TaxpayerIdentificationNumber = c.String(maxLength: 9)
                })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Account", t => t.TaxpayerIdentificationNumber)
                .Index(t => t.TaxpayerIdentificationNumber);

            CreateTable(
                "dbo.Task",
                c => new
                {
                    TaskId = c.Int(false, true),
                    Name = c.String(false, 50),
                    AccountId = c.String(maxLength: 9),
                    ProjectId = c.Int(false)
                })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.Account", t => t.AccountId)
                .ForeignKey("dbo.Project", t => t.ProjectId, true)
                .Index(t => t.AccountId)
                .Index(t => t.ProjectId);

            CreateTable(
                "dbo.Activity",
                c => new
                {
                    ActivityId = c.Int(false, true),
                    StartDate = c.DateTime(false),
                    EndDate = c.DateTime(false),
                    DurationInHours = c.Int(false),
                    Description = c.String(maxLength: 500),
                    IsApproved = c.Boolean(false),
                    EmployeeId = c.Int(false)
                })
                .PrimaryKey(t => t.ActivityId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId, true)
                .Index(t => t.EmployeeId);

            CreateTable(
                "dbo.Employee",
                c => new
                {
                    EmployeeId = c.Int(false, true),
                    FirstName = c.String(false, 30),
                    LastName = c.String(false, 50),
                    Email = c.String(false, 80)
                })
                .PrimaryKey(t => t.EmployeeId)
                .Index(t => t.Email, unique: true);

            CreateTable(
                "dbo.TaskActivity",
                c => new
                {
                    TaskId = c.Int(false),
                    ActivityId = c.Int(false)
                })
                .PrimaryKey(t => new {t.TaskId, t.ActivityId})
                .ForeignKey("dbo.Activity", t => t.ActivityId, true)
                .ForeignKey("dbo.Task", t => t.TaskId, true)
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
            DropIndex("dbo.TaskActivity", new[] {"ActivityId"});
            DropIndex("dbo.TaskActivity", new[] {"TaskId"});
            DropIndex("dbo.Employee", new[] {"Email"});
            DropIndex("dbo.Activity", new[] {"EmployeeId"});
            DropIndex("dbo.Task", new[] {"ProjectId"});
            DropIndex("dbo.Task", new[] {"AccountId"});
            DropIndex("dbo.Project", new[] {"TaxpayerIdentificationNumber"});
            DropTable("dbo.TaskActivity");
            DropTable("dbo.Employee");
            DropTable("dbo.Activity");
            DropTable("dbo.Task");
            DropTable("dbo.Project");
            DropTable("dbo.Account");
        }
    }
}