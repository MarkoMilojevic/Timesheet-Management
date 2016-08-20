using System.Data.Entity.Migrations;

namespace TimesheetManagement.Data.EntityFramework.Migrations
{
	public partial class Initial : DbMigration
	{
		public override void Up()
		{
			this.CreateTable(
				"dbo.Account",
				c => new
				{
					TaxpayerIdentificationNumber = c.String(false, 9),
					Name = c.String(false, 50),
					RegisterNumber = c.String(false, 8)
				})
				.PrimaryKey(t => t.TaxpayerIdentificationNumber);

			this.CreateTable(
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

			this.CreateTable(
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

			this.CreateTable(
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

			this.CreateTable(
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

			this.CreateTable(
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
			this.DropForeignKey("dbo.TaskActivity", "TaskId", "dbo.Task");
			this.DropForeignKey("dbo.TaskActivity", "ActivityId", "dbo.Activity");
			this.DropForeignKey("dbo.Activity", "EmployeeId", "dbo.Employee");
			this.DropForeignKey("dbo.Task", "ProjectId", "dbo.Project");
			this.DropForeignKey("dbo.Task", "AccountId", "dbo.Account");
			this.DropForeignKey("dbo.Project", "TaxpayerIdentificationNumber", "dbo.Account");
			this.DropIndex("dbo.TaskActivity", new[] {"ActivityId"});
			this.DropIndex("dbo.TaskActivity", new[] {"TaskId"});
			this.DropIndex("dbo.Employee", new[] {"Email"});
			this.DropIndex("dbo.Activity", new[] {"EmployeeId"});
			this.DropIndex("dbo.Task", new[] {"ProjectId"});
			this.DropIndex("dbo.Task", new[] {"AccountId"});
			this.DropIndex("dbo.Project", new[] {"TaxpayerIdentificationNumber"});
			this.DropTable("dbo.TaskActivity");
			this.DropTable("dbo.Employee");
			this.DropTable("dbo.Activity");
			this.DropTable("dbo.Task");
			this.DropTable("dbo.Project");
			this.DropTable("dbo.Account");
		}
	}
}
