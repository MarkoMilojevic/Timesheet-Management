﻿using System.Collections.Generic;
using TimesheetManagement.Business.Tasks.Entities;

namespace TimesheetManagement.Data.Repositories
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
