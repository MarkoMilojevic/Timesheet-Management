using System.Collections.Generic;
using TimesheetManagement.Data.Tasks.Entities;

namespace TimesheetManagement.Data.Interfaces.Tasks
{
	public interface ITaskRepository
	{
		Account GetAccount(string tin);

		ICollection<Account> GetAccounts();

		Project GetProject(int projectId);

		ICollection<Project> GetProjects(string accountId);

		Task GetTask(int taskId);

		ICollection<Task> GetTasks(int projectId);

		ICollection<TaskActivity> GetTaskActivities(int employeeId);

	    void CreateTaskActivity(TaskActivity taskActivity);
	}
}
