﻿using System.Collections.Generic;
using TimesheetManagement.Business.Tasks.Entities.Entities;


namespace TimesheetManagement.Business.Interfaces.Tasks
{
    public interface ITasksManager
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
