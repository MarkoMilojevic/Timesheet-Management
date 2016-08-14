﻿using System.Collections.Generic;
using TimesheetManagement.Business.Entities;

namespace TimesheetManagement.Business.Services
{
	public interface ITimesheetService
	{
		Client GetClient(string tin);

		ICollection<Client> GetClients();

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