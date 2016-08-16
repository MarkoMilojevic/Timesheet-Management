using System.Collections.Generic;
using System.Linq;
using TimesheetManagement.Data.EntityFramework.Common;
using TimesheetManagement.Data.EntityFramework.Entities;
using TimesheetManagement.Data.Repositories;
using TimesheetManagement.Data.Tasks.Repositories;
using EmployeeDTO = TimesheetManagement.Data.Entities.Employee;
using ActivityDTO = TimesheetManagement.Data.Entities.Activity;
using AccountDTO = TimesheetManagement.Data.Tasks.Entities.Account;
using ProjectDTO = TimesheetManagement.Data.Tasks.Entities.Project;
using TaskDTO = TimesheetManagement.Data.Tasks.Entities.Task;
using TaskActivityDTO = TimesheetManagement.Data.Tasks.Entities.TaskActivity;

namespace TimesheetManagement.Data.EntityFramework.Repositories
{
	public class EntityFrameworkRepository : ITaskRepository, IActivityRepository, IEmployeeRepository
	{
		private readonly TimesheetContext context;

		public EntityFrameworkRepository()
		{
			this.context = new TimesheetContext();
		}

        public EmployeeDTO GetEmployee(int employeeId)
        {
            Employee employee = this.context.Employees.Find(employeeId);

            return EntityFrameworkAutoMapper.CreateEmployee(employee);
        }

        public EmployeeDTO GetEmployee(string email)
        {
            Employee employee = this.context.Employees.FirstOrDefault(e => e.Email == email);

            return EntityFrameworkAutoMapper.CreateEmployee(employee);
        }

        public ICollection<EmployeeDTO> GetEmployees()
        {
            List<Employee> employees = this.context.Employees.ToList();

            return employees.Select(EntityFrameworkAutoMapper.CreateEmployee).ToList();
        }

        public ActivityDTO GetActivity(int activityId)
		{
			Activity activity = this.context.Activities.Find(activityId);

			return EntityFrameworkAutoMapper.CreateActivity(activity);
		}

		public ICollection<ActivityDTO> GetActivities(int employeeId)
		{
			List<Activity> activities = this.context.Activities.Where(a => a.EmployeeId == employeeId).ToList();

			return activities.Select(EntityFrameworkAutoMapper.CreateActivity).ToList();
		}

		public AccountDTO GetAccount(string tin)
		{
			Account client = this.context.Accounts.Find(tin);

			return EntityFrameworkAutoMapper.CreateAccount(client);
		}

		public ICollection<AccountDTO> GetAccounts()
		{
			List<Account> clients = this.context.Accounts.ToList();

			return clients.Select(EntityFrameworkAutoMapper.CreateAccount).ToList();
		}

		public ProjectDTO GetProject(int projectId)
		{
			Project project = this.context.Projects.Find(projectId);

			return EntityFrameworkAutoMapper.CreateProject(project);
		}

		public ICollection<ProjectDTO> GetProjects(string accountTin)
		{
			List<Project> projects = this.context.Projects.Where(p => p.TaxpayerIdentificationNumber == accountTin).ToList();

			return projects.Select(EntityFrameworkAutoMapper.CreateProject).ToList();
		}

		public TaskDTO GetTask(int taskId)
		{
			Task task = this.context.Tasks.Find(taskId);

			return EntityFrameworkAutoMapper.CreateTask(task);
		}

		ICollection<TaskDTO> ITaskRepository.GetTasks(int projectId)
		{
			List<Task> tasks = this.context.Tasks.Where(p => p.ProjectId == projectId).ToList();

			return tasks.Select(EntityFrameworkAutoMapper.CreateTask).ToList();
		}

		public ICollection<TaskActivityDTO> GetTaskActivities(int taskId)
		{
			List<TaskActivity> taskActivities = this.context.TaskActivities.Where(ta => ta.TaskId == taskId).ToList();

			return taskActivities.Select(EntityFrameworkAutoMapper.CreateTaskActivity).ToList();
		}

		public ICollection<TaskActivityDTO> GetTaskActivities(int taskId, int employeeId)
		{
            List<TaskActivity> taskActivities = this.context.TaskActivities.Where(ta => ta.TaskId == taskId && ta.Activity != null && ta.Activity.EmployeeId == employeeId).ToList();

            return taskActivities.Select(EntityFrameworkAutoMapper.CreateTaskActivity).ToList();
        }
	}
}
