using System.Collections.Generic;
using TimesheetManagement.Business.Entities;

namespace TimesheetManagement.Data.Repositories
{
	public interface IEmployeeRepository
	{
		Employee GetEmployee(int employeeId);

		Employee GetEmployee(string email);

		ICollection<Employee> GetEmployees();
	}
}
