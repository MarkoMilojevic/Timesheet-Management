using System.Collections.Generic;
using System.Threading.Tasks;
using TimesheetManagement.Business.Tasks.Entities;

namespace TimesheetManagement.Service
{
	public interface ITimesheetService
	{
		Task<Account> GetAccountAsync(string tin);

        Task<ICollection<Account>> GetAccountsAsync();

        Task<Project> GetProjectAsync(int id);

        Task<ICollection<Project>> GetProjectsAsync();

        Task<Activity> GetActivityAsync(int id);

        Task<ICollection<Activity>> GetActivitiesAsync(int projectId);

        Task<Employee> GetEmployeeAsync(int id);

        Task<Employee> GetEmployeeAsync(string email);

        Task<ICollection<Employee>> GetEmployeesAsync();

        Task<ICollection<EmployeeActivity>> GetEmployeeActivitiesAsync(int employeeId);
	}
}
