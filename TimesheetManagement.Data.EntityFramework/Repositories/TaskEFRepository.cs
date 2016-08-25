using System.Collections.Generic;
using System.Linq;
using TimesheetManagement.Data.EntityFramework.Entities;
using TimesheetManagement.Data.EntityFramework.Helpers;
using TimesheetManagement.Data.Interfaces.Tasks;
using AccountDTO = TimesheetManagement.Data.Tasks.Entities.Account;
using ProjectDTO = TimesheetManagement.Data.Tasks.Entities.Project;
using TaskDTO = TimesheetManagement.Data.Tasks.Entities.Task;
using TaskActivityDTO = TimesheetManagement.Data.Tasks.Entities.TaskActivity;

namespace TimesheetManagement.Data.EntityFramework.Repositories
{
	public class TaskEFRepository : ITaskRepository
	{
		private readonly TimesheetContext context;

		public TaskEFRepository()
		{
			this.context = new TimesheetContext();
		}

		public AccountDTO GetAccount(string tin)
		{
			Account client = this.context.Accounts.Find(tin);

			return EfDtoMapper.CreateAccount(client);
		}

		public ICollection<AccountDTO> GetAccounts()
		{
			List<Account> clients = this.context.Accounts.ToList();

			return clients.Select(EfDtoMapper.CreateAccount).ToList();
		}

		public ProjectDTO GetProject(int projectId)
		{
			Project project = this.context.Projects.Find(projectId);

			return EfDtoMapper.CreateProject(project);
		}

		public ICollection<ProjectDTO> GetProjects(string accountId)
		{
			List<Project> projects = this.context.Projects.Where(p => p.AccountId == accountId).ToList();

			return projects.Select(EfDtoMapper.CreateProject).ToList();
		}

		public TaskDTO GetTask(int taskId)
		{
			Task task = this.context.Tasks.Find(taskId);

			return EfDtoMapper.CreateTask(task);
		}

		public ICollection<TaskDTO> GetTasks(int projectId)
		{
			List<Task> tasks = this.context.Tasks.Where(t => t.ProjectId == projectId).ToList();

			return tasks.Select(EfDtoMapper.CreateTask).ToList();
		}

		public ICollection<TaskActivityDTO> GetTaskActivities(int employeeId)
		{
			List<TaskActivity> taskActivities = this.context.TaskActivities.Where(ta => ta.Activity.EmployeeId == employeeId).ToList();

			return taskActivities.Select(EfDtoMapper.CreateTaskActivity).ToList();
		}

		public ICollection<TaskActivityDTO> GetTaskActivities(int taskId, int employeeId)
		{
			List<TaskActivity> taskActivities =
				this.context.TaskActivities.Where(ta => (ta.TaskId == taskId) && (ta.Activity != null) && (ta.Activity.EmployeeId == employeeId)).ToList();

			return taskActivities.Select(EfDtoMapper.CreateTaskActivity).ToList();
		}
	}
}
