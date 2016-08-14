using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TimesheetManagement.Data.EntityFramework.Entities
{
	public class TimesheetContext : DbContext
	{
		public DbSet<Client> Clients { get; set; }

		public DbSet<Project> Projects { get; set; }

		public DbSet<Activity> Activities { get; set; }

		public DbSet<Employee> Employees { get; set; }

		public DbSet<EmployeeActivity> EmployeeActivities { get; set; }

		public TimesheetContext()
			: base("TimesheetConnection")
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}
