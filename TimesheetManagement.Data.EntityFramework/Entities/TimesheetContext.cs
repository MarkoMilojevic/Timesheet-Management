using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TimesheetManagement.Data.EntityFramework.Entities
{
    public class TimesheetContext : DbContext
    {
        public TimesheetContext() : base("TimesheetConnection2")
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<TaskActivity> TaskActivities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}