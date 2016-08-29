using System.Collections.Generic;
using TimesheetManagement.Business.Tasks.Entities;
using TimesheetManagement.Business.Tasks.Models;

namespace TimesheetManagement.Business.Tasks.Interfaces
{
    public interface ITasksManager
    {
        Account GetAccount(string accountId);

        ICollection<Account> GetAccounts();

        Project GetProject(int projectId);

        ICollection<Project> GetProjects(string accountId);

        Task GetTask(int taskId);

        ICollection<Task> GetTasks(int projectId);

        ICollection<TaskActivityViewModel> GetTaskActivities(int employeeId);

        void CreateTaskActivity(TaskActivity taskActivity);
    }
}