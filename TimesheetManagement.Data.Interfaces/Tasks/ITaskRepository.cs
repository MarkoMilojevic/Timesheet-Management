using System.Collections.Generic;
using TimesheetManagement.Data.Tasks.Entities;

namespace TimesheetManagement.Data.Interfaces.Tasks
{
	public interface ITaskRepository
	{
		Account GetAccount(string tin);

		ICollection<Account> GetAccounts();

		Project GetProject(int projectId);

		ICollection<Project> GetProjects();

		Task GetTask(int taskId);

		ICollection<Task> GetTasks();

		ICollection<TaskActivity> GetTaskActivities(int employeeId);

		ICollection<TaskActivity> GetTaskActivities(int taskId, int employeeId);
	}
}
