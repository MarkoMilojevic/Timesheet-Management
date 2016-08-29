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
	public class TaskRepository : ITaskRepository
	{
		private readonly TimesheetContext context;

		public TaskRepository()
		{
			this.context = new TimesheetContext();
		}

		public AccountDTO GetAccount(string accountId)
		{
			Account client = this.context.Accounts.Find(accountId);

			return EfDtoMapper.CreateAccountDto(client);
		}

		public ICollection<AccountDTO> GetAccounts()
		{
			List<Account> clients = this.context.Accounts.ToList();

			return clients.Select(EfDtoMapper.CreateAccountDto).ToList();
		}

		public ProjectDTO GetProject(int projectId)
		{
			Project project = this.context.Projects.Find(projectId);

			return EfDtoMapper.CreateProjectDto(project);
		}

		public ICollection<ProjectDTO> GetProjects(string accountId)
		{
			List<Project> projects = this.context.Projects.Where(p => p.AccountId == accountId).ToList();

			return projects.Select(EfDtoMapper.CreateProjectDto).ToList();
		}

		public TaskDTO GetTask(int taskId)
		{
			Task task = this.context.Tasks.Find(taskId);

			return EfDtoMapper.CreateTaskDto(task);
		}

		public ICollection<TaskDTO> GetTasks(int projectId)
		{
			List<Task> tasks = this.context.Tasks.Where(t => t.ProjectId == projectId).ToList();

			return tasks.Select(EfDtoMapper.CreateTaskDto).ToList();
		}

		public ICollection<TaskActivityDTO> GetTaskActivities(int employeeId)
		{
			List<TaskActivity> taskActivities = this.context.TaskActivities.Where(ta => ta.Activity.EmployeeId == employeeId).ToList();

			return taskActivities.Select(EfDtoMapper.CreateTaskActivityDto).ToList();
		}

	    public void CreateTaskActivity(TaskActivityDTO taskActivity)
	    {
	        TaskActivity ta = EfDtoMapper.CreateTaskActivity(taskActivity);
            this.context.TaskActivities.Add(ta);
	        this.context.SaveChanges();
	    }
	}
}
