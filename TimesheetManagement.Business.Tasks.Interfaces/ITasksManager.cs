using System.Collections.Generic;
using TimesheetManagement.Business.Tasks.Entities;
using TimesheetManagement.Business.Tasks.Models;

namespace TimesheetManagement.Business.Tasks.Interfaces
{
    public interface ITasksManager
    {
        Account GetAccount(string tin);

        ICollection<Account> GetAccounts();

        Project GetProject(int projectId);

        ICollection<Project> GetProjects(string accountTin);

        Task GetTask(int taskId);

        ICollection<Task> GetTasks(int projectId);

        ICollection<TaskActivityViewModel> GetTaskActivities(int employeeId);
    }
}