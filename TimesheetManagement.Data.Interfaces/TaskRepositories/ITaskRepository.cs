using System.Collections.Generic;
using TimesheetManagement.Data.Tasks.Entities;

namespace TimesheetManagement.Data.Interfaces.TaskRepositories
{
	public interface ITaskRepository
	{
		Account GetAccount(string tin);

		ICollection<Account> GetAccounts();

		Project GetProject(int projectId);

		ICollection<Project> GetProjects(string accountTin);

		Task GetTask(int taskId);

		ICollection<Task> GetTasks(int projectId);

		ICollection<TaskActivity> GetTaskActivities(int taskId);

		ICollection<TaskActivity> GetTaskActivities(int taskId, int employeeId);
	}
}
