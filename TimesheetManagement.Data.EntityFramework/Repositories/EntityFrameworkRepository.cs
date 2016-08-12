using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetManagement.Data.EntityFramework.Common;
using TimesheetManagement.Data.EntityFramework.Entities;
using TimesheetManagement.Data.Repositories;
using ActivityDTO = TimesheetManagement.Business.DataContracts.Activity;
using ClientDTO = TimesheetManagement.Business.DataContracts.Client;
using EmployeeDTO = TimesheetManagement.Business.DataContracts.Employee;
using EmployeeActivityDTO = TimesheetManagement.Business.DataContracts.EmployeeActivity;
using ProjectDTO = TimesheetManagement.Business.DataContracts.Project;

namespace TimesheetManagement.Data.EntityFramework.Repositories
{
    public class EntityFrameworkRepository : IRepository
    {
        private readonly TimesheetContext _context;

        public EntityFrameworkRepository()
        {
            _context = new TimesheetContext();
        }

        public ClientDTO GetClient(string tin)
        {
            Client client = _context.Clients.Find(tin);

            return EntityFrameworkAutoMapper.CreateClient(client);
        }

        public ICollection<ClientDTO> GetClients()
        {
            List<Client> clients = _context.Clients.ToList();

            return clients.Select(EntityFrameworkAutoMapper.CreateClient).ToList();
        }

        public ProjectDTO GetProject(int id)
        {
            Project project = _context.Projects.Find(id);

            return EntityFrameworkAutoMapper.CreateProject(project);
        }

        public ICollection<ProjectDTO> GetProjects()
        {
            List<Project> projects = _context.Projects.ToList();

            return projects.Select(EntityFrameworkAutoMapper.CreateProject).ToList();
        }

        public ActivityDTO GetActivity(int id)
        {
            Activity activity = _context.Activities.Find(id);

            return EntityFrameworkAutoMapper.CreateActivity(activity);
        }

        public ICollection<ActivityDTO> GetActivities(int projectId)
        {
            List<Activity> activities = _context.Activities.ToList();

            return activities.Select(EntityFrameworkAutoMapper.CreateActivity).ToList();
        }

        public EmployeeDTO GetEmployee(int id)
        {
            Employee employee = _context.Employees.Find(id);

            return EntityFrameworkAutoMapper.CreateEmployee(employee);
        }

        public EmployeeDTO GetEmployee(string email)
        {
            Employee employee = _context.Employees.FirstOrDefault(e => e.Email == email);

            return EntityFrameworkAutoMapper.CreateEmployee(employee);
        }

        public ICollection<EmployeeDTO> GetEmployees()
        {
            List<Employee> employees = _context.Employees.ToList();

            return employees.Select(EntityFrameworkAutoMapper.CreateEmployee).ToList();
        }

        public ICollection<EmployeeActivityDTO> GetEmployeeActivities(int employeeId)
        {
            List<EmployeeActivity> employeeActivities = _context.EmployeeActivities.Where(ea => ea.EmployeeId == employeeId).ToList();

            return employeeActivities.Select(EntityFrameworkAutoMapper.CreateEmployeeActivity).ToList();
        }
    }
}