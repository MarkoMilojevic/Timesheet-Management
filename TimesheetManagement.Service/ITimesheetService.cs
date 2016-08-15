using System.Collections.Generic;
using TimesheetManagement.Business.Tasks.Entities;

namespace TimesheetManagement.Service
{
	public interface ITimesheetService
	{
		Account GetClient(string tin);

		ICollection<Account> GetClients();

		Project GetProject(int id);

		ICollection<Project> GetProjects();

		Activity GetActivity(int id);

		ICollection<Activity> GetActivities(int projectId);

		Employee GetEmployee(int id);

		Employee GetEmployee(string email);

		ICollection<Employee> GetEmployees();

		ICollection<EmployeeActivity> GetEmployeeActivities(int employeeId);
	}
}
