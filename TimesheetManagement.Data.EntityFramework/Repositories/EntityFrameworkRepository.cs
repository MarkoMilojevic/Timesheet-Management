using System.Collections.Generic;
using System.Linq;
using TimesheetManagement.Data.EntityFramework.Common;
using TimesheetManagement.Data.EntityFramework.Entities;
using TimesheetManagement.Data.Repositories;
using ActivityBO = TimesheetManagement.Business.Entities.Activity;
using ClientBO = TimesheetManagement.Business.Entities.Client;
using EmployeeBO = TimesheetManagement.Business.Entities.Employee;
using EmployeeActivityBO = TimesheetManagement.Business.Entities.EmployeeActivity;
using ProjectBO = TimesheetManagement.Business.Entities.Project;

namespace TimesheetManagement.Data.EntityFramework.Repositories
{
    public class EntityFrameworkRepository : IRepository
    {
        private readonly TimesheetContext _context;

        public EntityFrameworkRepository()
        {
            _context = new TimesheetContext();
        }

        public ClientBO GetClient(string tin)
        {
            Client client = _context.Clients.Find(tin);

            return EntityFrameworkAutoMapper.CreateClient(client);
        }

        public ICollection<ClientBO> GetClients()
        {
            List<Client> clients = _context.Clients.ToList();

            return clients.Select(EntityFrameworkAutoMapper.CreateClient).ToList();
        }

        public ProjectBO GetProject(int id)
        {
            Project project = _context.Projects.Find(id);

            return EntityFrameworkAutoMapper.CreateProject(project);
        }

        public ICollection<ProjectBO> GetProjects()
        {
            List<Project> projects = _context.Projects.ToList();

            return projects.Select(EntityFrameworkAutoMapper.CreateProject).ToList();
        }

        public ActivityBO GetActivity(int id)
        {
            Activity activity = _context.Activities.Find(id);

            return EntityFrameworkAutoMapper.CreateActivity(activity);
        }

        public ICollection<ActivityBO> GetActivities(int projectId)
        {
            List<Activity> activities = _context.Activities.ToList();

            return activities.Select(EntityFrameworkAutoMapper.CreateActivity).ToList();
        }

        public EmployeeBO GetEmployee(int id)
        {
            Employee employee = _context.Employees.Find(id);

            return EntityFrameworkAutoMapper.CreateEmployee(employee);
        }

        public EmployeeBO GetEmployee(string email)
        {
            Employee employee = _context.Employees.FirstOrDefault(e => e.Email == email);

            return EntityFrameworkAutoMapper.CreateEmployee(employee);
        }

        public ICollection<EmployeeBO> GetEmployees()
        {
            List<Employee> employees = _context.Employees.ToList();

            return employees.Select(EntityFrameworkAutoMapper.CreateEmployee).ToList();
        }

        public ICollection<EmployeeActivityBO> GetEmployeeActivities(int employeeId)
        {
            List<EmployeeActivity> employeeActivities = _context.EmployeeActivities.Where(ea => ea.EmployeeId == employeeId).ToList();

            return employeeActivities.Select(EntityFrameworkAutoMapper.CreateEmployeeActivity).ToList();
        }
    }
}