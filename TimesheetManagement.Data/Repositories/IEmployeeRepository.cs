﻿using System.Collections.Generic;
using TimesheetManagement.Data.Entities;

namespace TimesheetManagement.Data.Repositories
{
	public interface IEmployeeRepository
	{
		Employee GetEmployee(int employeeId);

		Employee GetEmployee(string email);

		ICollection<Employee> GetEmployees();
	}
}
