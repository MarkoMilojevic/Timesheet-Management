using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Runtime.InteropServices;
using System.Security.AccessControl;

namespace TimesheetManagement.Data.EntityFramework.Entities
{
    public class TimesheetContext : DbContext
    {
        public TimesheetContext()
            : base("TimesheetConnection")
        {
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeActivity> EmployeeActivities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}