using System.Collections.Generic;
using System.Linq;
using TimesheetManagement.Business.Interfaces.Tasks;
using TimesheetManagement.Business.Tasks.Common;
using TimesheetManagement.Business.Tasks.Entities;
using TimesheetManagement.Data.Interfaces.Tasks;
using AccountDTO = TimesheetManagement.Data.Tasks.Entities.Account;
using ProjectDTO = TimesheetManagement.Data.Tasks.Entities.Project;
using TaskDTO = TimesheetManagement.Data.Tasks.Entities.Task;
using TaskActivityDTO = TimesheetManagement.Data.Tasks.Entities.TaskActivity;

namespace TimesheetManagement.Business.Tasks.Managers
{
    public class TasksManager : ITasksManager
    {
        private readonly ITaskRepository repository;

        public TasksManager(ITaskRepository repository)
        {
            this.repository = repository;
        }

        public Account GetAccount(string tin)
        {
            AccountDTO account = repository.GetAccount(tin);

            return TasksBoMapper.CreateAccount(account);
        }

        public ICollection<Account> GetAccounts()
        {
            ICollection<AccountDTO> clients = repository.GetAccounts();

            return clients.Select(TasksBoMapper.CreateAccount).ToList();
        }

        public Project GetProject(int projectId)
        {
            ProjectDTO project = repository.GetProject(projectId);

            return TasksBoMapper.CreateProject(project);
        }

        public ICollection<Project> GetProjects(string accountTin)
        {
            ICollection<ProjectDTO> projects = repository.GetProjects(accountTin);

            return projects.Select(TasksBoMapper.CreateProject).ToList();
        }

        public Task GetTask(int taskId)
        {
            TaskDTO task = repository.GetTask(taskId);

            return TasksBoMapper.CreateTask(task);
        }

        public ICollection<Task> GetTasks(int projectId)
        {
            ICollection<TaskDTO> tasks = repository.GetTasks(projectId);

            return tasks.Select(TasksBoMapper.CreateTask).ToList();
        }

        public ICollection<TaskActivity> GetTaskActivities(int taskId)
        {
            ICollection<TaskActivityDTO> taskActivities = repository.GetTaskActivities(taskId);

            return taskActivities.Select(TasksBoMapper.CreateTaskActivity).ToList();
        }

        public ICollection<TaskActivity> GetTaskActivities(int taskId, int employeeId)
        {
            ICollection<TaskActivityDTO> taskActivities = repository.GetTaskActivities(taskId, employeeId);

            return taskActivities.Select(TasksBoMapper.CreateTaskActivity).ToList();
        }
    }
}
