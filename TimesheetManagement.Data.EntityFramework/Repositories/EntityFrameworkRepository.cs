using System;
using System.Collections.Generic;
using System.Linq;
using TimesheetManagement.Data.EntityFramework.Common;
using TimesheetManagement.Data.EntityFramework.Entities;
using TimesheetManagement.Data.Repositories;
using EmployeeBO = TimesheetManagement.Business.Entities.Employee;
using ActivityBO = TimesheetManagement.Business.Entities.Activity;
using AccountBO = TimesheetManagement.Business.Tasks.Entities.Account;
using ProjectBO = TimesheetManagement.Business.Tasks.Entities.Project;
using TaskBO = TimesheetManagement.Business.Tasks.Entities.Task;
using TaskActivityBO = TimesheetManagement.Business.Tasks.Entities.TaskActivity;

namespace TimesheetManagement.Data.EntityFramework.Repositories
{
	public class EntityFrameworkRepository : ITaskRepository, IActivityRepository, IEmployeeRepository
	{
		private readonly TimesheetContext context;

		public EntityFrameworkRepository()
		{
			this.context = new TimesheetContext();
		}

		public ActivityBO GetActivity(int id)
		{
			Activity activity = this.context.Activities.Find(id);

			return EntityFrameworkAutoMapper.CreateActivity(activity);
		}

		public ICollection<ActivityBO> GetActivities(int employeeId)
		{
			List<Activity> activities = this.context.Activities.Where(a => a.EmployeeId == employeeId).ToList();

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

		public AccountBO GetAccount(string tin)
		{
			Account client = this.context.Accounts.Find(tin);

			return EntityFrameworkAutoMapper.CreateAccount(client);
		}

		public ICollection<AccountBO> GetAccounts()
		{
			List<Account> clients = this.context.Accounts.ToList();

			return clients.Select(EntityFrameworkAutoMapper.CreateAccount).ToList();
		}

		public ProjectBO GetProject(int projectId)
		{
			Project project = this.context.Projects.Find(projectId);

			return EntityFrameworkAutoMapper.CreateProject(project);
		}

		public ICollection<ProjectBO> GetProjects(string accountTin)
		{
			List<Project> projects = this.context.Projects.Where(p => p.TaxpayerIdentificationNumber == accountTin).ToList();

			return projects.Select(EntityFrameworkAutoMapper.CreateProject).ToList();
		}

		public TaskBO GetTask(int taskId)
		{
			Task task = this.context.Tasks.Find(taskId);

			return EntityFrameworkAutoMapper.CreateTask(task);
		}

		ICollection<TaskBO> ITaskRepository.GetTasks(int projectId)
		{
			List<Task> tasks = this.context.Tasks.Where(p => p.ProjectId == projectId).ToList();

			return tasks.Select(EntityFrameworkAutoMapper.CreateTask).ToList();
		}

		public ICollection<TaskActivityBO> GetTaskActivities(int taskId)
		{
			List<TaskActivity> taskActivities = this.context.TaskActivities.Where(ta => ta.TaskId == taskId).ToList();

			return taskActivities.Select(EntityFrameworkAutoMapper.CreateTaskActivity).ToList();
		}

		public ICollection<TaskActivityBO> GetTaskActivities(int taskId, int employeeId)
		{
            List<TaskActivity> taskActivities = this.context.TaskActivities.Where(ta => ta.TaskId == taskId && ta.Activity != null && ta.Activity.EmployeeId == employeeId).ToList();

            return taskActivities.Select(EntityFrameworkAutoMapper.CreateTaskActivity).ToList();
        }
	}
}
