namespace TimesheetManagement.Data.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TimesheetManagement.Data.EntityFramework.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<TimesheetManagement.Data.EntityFramework.Entities.TimesheetContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TimesheetManagement.Data.EntityFramework.Entities.TimesheetContext context)
        {
            context.Clients.AddOrUpdate(cl => cl.Name,
                new Client { Name = "Microsoft", TaxpayerIdentificationNumber = "123456789", RegisterNumber = "12345678" },
                new Client { Name = "Coca Cola", TaxpayerIdentificationNumber = "987654321", RegisterNumber = "87654321" });

            context.Employees.AddOrUpdate(em => em.FirstName,
                new Employee { Email = "marko@gmail.com", FirstName = "Marko", LastName = "Milojevic" },
                new Employee { Email = "ilija@gmail.com", FirstName = "Ilija", LastName = "Divljan" });

            context.Projects.AddOrUpdate(pr => pr.Name,
                new Project { Name = "New Year Marketing", StartDate = DateTime.Now, DueDate = new DateTime(2016, 12, 31), TaxpayerIdentificationNumber = "987654321" },
                new Project { Name = "Developing new flavours", StartDate = DateTime.Now, DueDate = new DateTime(2016, 12, 31), TaxpayerIdentificationNumber = "987654321" },
                new Project { Name = "Timesheet-Management System", StartDate = DateTime.Now, DueDate = new DateTime(2017, 3, 31), TaxpayerIdentificationNumber = "123456789" });

            context.SaveChanges();

            var firstOrDefault = context.Projects.FirstOrDefault(p => p.Name == "New Year Marketing");
            if (firstOrDefault != null)
            {
                context.Activities.AddOrUpdate(a => a.Name,
                    new Activity
                    {
                        ClientId = "987654321",
                        Name = "Shooting Commercial",
                        ProjectId = firstOrDefault.ProjectId
                    },
                    new Activity
                    {
                        ClientId = "987654321",
                        Name = "Making flyers",
                        ProjectId = firstOrDefault.ProjectId
                    });
            }

            firstOrDefault = context.Projects.FirstOrDefault(p => p.Name == "Timesheet-Management System");
            if (firstOrDefault != null)
            {
                context.Activities.AddOrUpdate(a => a.Name,
                    new Activity
                    {
                        ClientId = "123456789",
                        Name = "Gathering Requirements",
                        ProjectId = firstOrDefault.ProjectId
                    },
                    new Activity
                    {
                        ClientId = "123456789",
                        Name = "Creating UML",
                        ProjectId = firstOrDefault.ProjectId
                    },
                    new Activity
                    {
                        ClientId = "123456789",
                        Name = "Developing solution",
                        ProjectId = firstOrDefault.ProjectId
                    },
                    new Activity
                    {
                        ClientId = "123456789",
                        Name = "Testing",
                        ProjectId = firstOrDefault.ProjectId
                    });
            }

            context.SaveChanges();

            context.EmployeeActivities.AddOrUpdate(ea => new { ea.EmployeeId, ea.ActivityId },
                new EmployeeActivity
                {
                    EmployeeId = context.Employees.FirstOrDefault(e => e.FirstName == "Marko").EmployeeId,
                    ActivityId = context.Activities.FirstOrDefault(a => a.Name == "Shooting Commercial").ActivityId
                },
                new EmployeeActivity
                {
                    EmployeeId = context.Employees.FirstOrDefault(e => e.FirstName == "Ilija").EmployeeId,
                    ActivityId = context.Activities.FirstOrDefault(a => a.Name == "Making flyers").ActivityId
                },
                new EmployeeActivity
                {
                    EmployeeId = context.Employees.FirstOrDefault(e => e.FirstName == "Marko").EmployeeId,
                    ActivityId = context.Activities.FirstOrDefault(a => a.Name == "Gathering Requirements").ActivityId
                },
                new EmployeeActivity
                {
                    EmployeeId = context.Employees.FirstOrDefault(e => e.FirstName == "Ilija").EmployeeId,
                    ActivityId = context.Activities.FirstOrDefault(a => a.Name == "Gathering Requirements").ActivityId
                },
                new EmployeeActivity
                {
                    EmployeeId = context.Employees.FirstOrDefault(e => e.FirstName == "Marko").EmployeeId,
                    ActivityId = context.Activities.FirstOrDefault(a => a.Name == "Creating UML").ActivityId
                },
                new EmployeeActivity
                {
                    EmployeeId = context.Employees.FirstOrDefault(e => e.FirstName == "Ilija").EmployeeId,
                    ActivityId = context.Activities.FirstOrDefault(a => a.Name == "Testing").ActivityId
                });
        }
    }
}
