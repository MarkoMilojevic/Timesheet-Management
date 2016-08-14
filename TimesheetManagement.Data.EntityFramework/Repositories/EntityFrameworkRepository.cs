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
		private readonly TimesheetContext context;

		public EntityFrameworkRepository()
		{
			this.context = new TimesheetContext();
		}

		public ClientBO GetClient(string tin)
		{
			Client client = this.context.Clients.Find(tin);

			return EntityFrameworkAutoMapper.CreateClient(client);
		}

		public ICollection<ClientBO> GetClients()
		{
			List<Client> clients = this.context.Clients.ToList();

			return clients.Select(EntityFrameworkAutoMapper.CreateClient).ToList();
		}

		public ProjectBO GetProject(int id)
		{
			Project project = this.context.Projects.Find(id);

			return EntityFrameworkAutoMapper.CreateProject(project);
		}

		public ICollection<ProjectBO> GetProjects()
		{
			List<Project> projects = this.context.Projects.ToList();

			return projects.Select(EntityFrameworkAutoMapper.CreateProject).ToList();
		}

		public ActivityBO GetActivity(int id)
		{
			Activity activity = this.context.Activities.Find(id);

			return EntityFrameworkAutoMapper.CreateActivity(activity);
		}

		public ICollection<ActivityBO> GetActivities(int projectId)
		{
			List<Activity> activities = this.context.Activities.ToList();

			return activities.Select(EntityFrameworkAutoMapper.CreateActivity).ToList();
		}

		public EmployeeBO GetEmployee(int id)
		{
			Employee employee = this.context.Employees.Find(id);

			return EntityFrameworkAutoMapper.CreateEmployee(employee);
		}

		public EmployeeBO GetEmployee(string email)
		{
			Employee employee = this.context.Employees.FirstOrDefault(e => e.Email == email);

			return EntityFrameworkAutoMapper.CreateEmployee(employee);
		}

		public ICollection<EmployeeBO> GetEmployees()
		{
			List<Employee> employees = this.context.Employees.ToList();

			return employees.Select(EntityFrameworkAutoMapper.CreateEmployee).ToList();
		}

		public ICollection<EmployeeActivityBO> GetEmployeeActivities(int employeeId)
		{
			List<EmployeeActivity> employeeActivities = this.context.EmployeeActivities.Where(ea => ea.EmployeeId == employeeId).ToList();

			return employeeActivities.Select(EntityFrameworkAutoMapper.CreateEmployeeActivity).ToList();
		}
	}
}
