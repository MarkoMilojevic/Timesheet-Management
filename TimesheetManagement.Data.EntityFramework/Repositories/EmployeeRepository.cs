﻿using System.Collections.Generic;
using System.Linq;
using TimesheetManagement.Data.EntityFramework.Entities;
using TimesheetManagement.Data.EntityFramework.Helpers;
using TimesheetManagement.Data.Interfaces.Common;
using EmployeeDTO = TimesheetManagement.Data.Entities.Employee;

namespace TimesheetManagement.Data.EntityFramework.Repositories
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly TimesheetContext context;

		public EmployeeRepository()
		{
			this.context = new TimesheetContext();
		}

		public EmployeeDTO GetEmployee(int employeeId)
		{
			Employee employee = this.context.Employees.Find(employeeId);

			return EfDtoMapper.CreateEmployeeDto(employee);
		}

		public EmployeeDTO GetEmployee(string email)
		{
			Employee employee = this.context.Employees.FirstOrDefault(e => e.Email == email);

			return EfDtoMapper.CreateEmployeeDto(employee);
		}

		public ICollection<EmployeeDTO> GetEmployees()
		{
			List<Employee> employees = this.context.Employees.ToList();

			return employees.Select(EfDtoMapper.CreateEmployeeDto).ToList();
		}
	}
}