using System.Collections.Generic;
using System.Threading.Tasks;
using TimesheetManagement.Business.Entities;
using TimesheetManagement.Business.Tasks.Entities;
using Task = System.Threading.Tasks.Task;

namespace TimesheetManagement.Service
{
	public interface ITimesheetService
	{
		Task<Employee> GetEmployeeAsync(int employeeId);

		Task<Employee> GetEmployeeAsync(string email);

		Task<ICollection<Employee>> GetEmployeesAsync();

		Task<Activity> GetActivityAsync(int activityId);

		Task<ICollection<Activity>> GetActivitiesAsync(int employeeId);

		Task<Account> GetAccountAsync(string tin);

		Task<ICollection<Account>> GetAccountsAsync();

		Task<Project> GetProjectAsync(int projectId);

		Task<ICollection<Project>> GetProjectsAsync(string accountTin);

		Task<Task> GetTaskAsync(int taskId);

		Task<ICollection<Task>> GetTasksAsync(int projectId);

		Task<ICollection<TaskActivity>> GetTaskActivitiesAsync(int taskId);
	}
}
