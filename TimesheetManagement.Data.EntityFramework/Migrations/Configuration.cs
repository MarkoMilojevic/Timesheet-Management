using System;
using System.Data.Entity.Migrations;
using System.Linq;
using TimesheetManagement.Data.EntityFramework.Entities;

namespace TimesheetManagement.Data.EntityFramework.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TimesheetContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TimesheetContext context)
        {
            context.Employees.AddOrUpdate(em => em.FirstName,
                new Employee {Email = "marko@gmail.com", FirstName = "Marko", LastName = "Milojevic"},
                new Employee {Email = "ilija@gmail.com", FirstName = "Ilija", LastName = "Divljan"});

            context.Clients.AddOrUpdate(cl => cl.Name,
                new Client {Name = "Microsoft", TaxpayerIdentificationNumber = "123456789", RegisterNumber = "12345678"},
                new Client {Name = "Coca Cola", TaxpayerIdentificationNumber = "987654321", RegisterNumber = "87654321"});

            context.Projects.AddOrUpdate(pr => pr.Name,
                new Project {Name = "New Year Marketing", StartDate = DateTime.Now, EndDate = new DateTime(2016, 12, 31), ClientId = "987654321"},
                new Project {Name = "Developing new flavours", StartDate = DateTime.Now, EndDate = new DateTime(2016, 12, 31), ClientId = "987654321"},
                new Project
                {
                    Name = "Timesheet-Management System",
                    StartDate = DateTime.Now,
                    EndDate = new DateTime(2017, 3, 31),
                    ClientId = "123456789"
                });
            context.SaveChanges();

            Project firstOrDefault = context.Projects.FirstOrDefault(p => p.Name == "New Year Marketing");
            if (firstOrDefault != null)
            {
                context.Tasks.AddOrUpdate(a => a.Name,
                    new Task
                    {
                        Name = "Shooting Commercial",
                        ProjectId = firstOrDefault.ProjectId
                    },
                    new Task
                    {
                        Name = "Making flyers",
                        ProjectId = firstOrDefault.ProjectId
                    });
            }

            firstOrDefault = context.Projects.FirstOrDefault(p => p.Name == "Timesheet-Management System");
            if (firstOrDefault != null)
            {
                context.Tasks.AddOrUpdate(a => a.Name,
                    new Task
                    {
                        Name = "Gathering Requirements",
                        ProjectId = firstOrDefault.ProjectId
                    },
                    new Task
                    {
                        Name = "Creating UML",
                        ProjectId = firstOrDefault.ProjectId
                    },
                    new Task
                    {
                        Name = "Developing solution",
                        ProjectId = firstOrDefault.ProjectId
                    },
                    new Task
                    {
                        Name = "Testing",
                        ProjectId = firstOrDefault.ProjectId
                    });
            }

            context.SaveChanges();

            context.Activities.AddOrUpdate(ac => new {ac.Description, ac.EmployeeId},
                new Activity
                {
                    Description = "Designing flyers in photoshop.",
                    EmployeeId = context.Employees.SingleOrDefault(e => e.Email == "marko@gmail.com").EmployeeId,
                    DurationInHours = 2,
                    StartDate = DateTime.Now,
                    EndDate = new DateTime(2016, 8, 17),
                    IsApproved = false
                },
                new Activity
                {
                    Description = "Marko Test",
                    EmployeeId = context.Employees.SingleOrDefault(e => e.Email == "marko@gmail.com").EmployeeId,
                    DurationInHours = 1,
                    StartDate = DateTime.Now,
                    EndDate = new DateTime(2016, 8, 17),
                    IsApproved = false
                },
                new Activity
                {
                    Description = "Printing Flyers.",
                    EmployeeId = context.Employees.SingleOrDefault(e => e.Email == "ilija@gmail.com").EmployeeId,
                    DurationInHours = 2,
                    StartDate = DateTime.Now,
                    EndDate = new DateTime(2016, 8, 18),
                    IsApproved = true
                },
                new Activity
                {
                    Description = "Ilija Test",
                    EmployeeId = context.Employees.SingleOrDefault(e => e.Email == "ilija@gmail.com").EmployeeId,
                    DurationInHours = 1,
                    StartDate = DateTime.Now,
                    EndDate = new DateTime(2016, 8, 18),
                    IsApproved = false
                });

            context.SaveChanges();

            context.TaskActivities.AddOrUpdate(t => new {t.TaskId, t.ActivityId},
                new TaskActivity
                {
                    TaskId = context.Tasks.SingleOrDefault(t => t.Name == "Making flyers").TaskId,
                    ActivityId = context.Activities.SingleOrDefault(a => a.Description == "Designing flyers in photoshop.").ActivityId
                },
                new TaskActivity
                {
                    TaskId = context.Tasks.SingleOrDefault(t => t.Name == "Making flyers").TaskId,
                    ActivityId = context.Activities.SingleOrDefault(a => a.Description == "Printing Flyers.").ActivityId
                },
                new TaskActivity
                {
                    TaskId = context.Tasks.SingleOrDefault(t => t.Name == "Developing solution").TaskId,
                    ActivityId = context.Activities.SingleOrDefault(a => a.Description == "Marko Test").ActivityId
                },
                new TaskActivity
                {
                    TaskId = context.Tasks.SingleOrDefault(t => t.Name == "Creating UML").TaskId,
                    ActivityId = context.Activities.SingleOrDefault(a => a.Description == "Ilija Test").ActivityId
                });

            context.SaveChanges();
        }
    }
}