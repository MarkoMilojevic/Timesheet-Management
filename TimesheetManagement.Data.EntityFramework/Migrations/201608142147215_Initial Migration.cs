namespace TimesheetManagement.Data.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activity",
                c => new
                    {
                        ActivityId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        ClientId = c.String(maxLength: 9),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ActivityId)
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Account", t => t.ClientId)
                .Index(t => t.ClientId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        TaxpayerIdentificationNumber = c.String(nullable: false, maxLength: 9),
                        Name = c.String(nullable: false, maxLength: 50),
                        RegisterNumber = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.TaxpayerIdentificationNumber);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        StartDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        TaxpayerIdentificationNumber = c.String(maxLength: 9),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Account", t => t.TaxpayerIdentificationNumber)
                .Index(t => t.TaxpayerIdentificationNumber);
            
            CreateTable(
                "dbo.EmployeeActivity",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        ActivityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmployeeId, t.ActivityId })
                .ForeignKey("dbo.Activity", t => t.ActivityId, cascadeDelete: true)
                .ForeignKey("dbo.Employee", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.ActivityId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 30),
                        LastName = c.String(maxLength: 30),
                        Email = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .Index(t => t.Email, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeActivity", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.EmployeeActivity", "ActivityId", "dbo.Activity");
            DropForeignKey("dbo.Activity", "AccountId", "dbo.Account");
            DropForeignKey("dbo.Project", "TaxpayerIdentificationNumber", "dbo.Account");
            DropForeignKey("dbo.Activity", "ProjectId", "dbo.Project");
            DropIndex("dbo.Employee", new[] { "Email" });
            DropIndex("dbo.EmployeeActivity", new[] { "ActivityId" });
            DropIndex("dbo.EmployeeActivity", new[] { "EmployeeId" });
            DropIndex("dbo.Project", new[] { "TaxpayerIdentificationNumber" });
            DropIndex("dbo.Activity", new[] { "ProjectId" });
            DropIndex("dbo.Activity", new[] { "AccountId" });
            DropTable("dbo.Employee");
            DropTable("dbo.EmployeeActivity");
            DropTable("dbo.Project");
            DropTable("dbo.Account");
            DropTable("dbo.Activity");
        }
    }
}
