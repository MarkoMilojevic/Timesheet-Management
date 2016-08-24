using System.Collections.Generic;
using System.Linq;
using TimesheetManagement.Business.Helpers;
using TimesheetManagement.Business.Tasks.Entities;
using TimesheetManagement.Business.Tasks.Interfaces;
using TimesheetManagement.Business.Tasks.Models;
using TimesheetManagement.Data.Interfaces.Common;
using TimesheetManagement.Data.Interfaces.Tasks;
using AccountDTO = TimesheetManagement.Data.Tasks.Entities.Account;
using ProjectDTO = TimesheetManagement.Data.Tasks.Entities.Project;
using TaskDTO = TimesheetManagement.Data.Tasks.Entities.Task;
using TaskActivityDTO = TimesheetManagement.Data.Tasks.Entities.TaskActivity;
using ActivityDTO = TimesheetManagement.Data.Entities.Activity;
using TimesheetManagement.Business.Tasks.Helpers;

namespace TimesheetManagement.Business.Tasks.Managers
{
    public class TasksManager : ITasksManager
    {
        private readonly IActivityRepository activityRepository;
        private readonly ITaskRepository taskRepository;

        public TasksManager(IActivityRepository activityRepository, ITaskRepository taskRepository)
        {
            this.activityRepository = activityRepository;
            this.taskRepository = taskRepository;
        }

        public Account GetAccount(string tin)
        {
            var account = taskRepository.GetAccount(tin);

            return TasksBoMapper.CreateAccount(account);
        }

        public ICollection<Account> GetAccounts()
        {
            var clients = taskRepository.GetAccounts();

            return clients.Select(TasksBoMapper.CreateAccount).ToList();
        }

        public Project GetProject(int projectId)
        {
            var project = taskRepository.GetProject(projectId);

            return TasksBoMapper.CreateProject(project);
        }

        public ICollection<Project> GetProjects(string accountTin)
        {
            //var projects = taskRepository.GetProjects(accountTin);

            //return projects.Select(TasksBoMapper.CreateProject).ToList();
            return null;
        }
        
        public Task GetTask(int taskId)
        {
            var task = taskRepository.GetTask(taskId);

            return TasksBoMapper.CreateTask(task);
        }

        public ICollection<Task> GetTasks(int projectId)
        {
            //var tasks = taskRepository.GetTasks(projectId);

            //return tasks.Select(TasksBoMapper.CreateTask).ToList();
            return null;
        }

        public ICollection<TaskActivityViewModel> GetTaskActivities(int employeeId)
        {
            ICollection<TaskActivityDTO> taskActivities = taskRepository.GetTaskActivities(employeeId);
            ICollection<TaskActivityViewModel> taViewModels = taskActivities.Select(taskActivity => new TaskActivityViewModel
            {
                Activity = CommonBoMapper.CreateActivity(taskActivity.Activity),
                TaskId = taskActivity.Task.TaskId,
                TaskName = taskActivity.Task.Name,
                ProjectId = taskActivity.Task.Project.ProjectId,
                AccountId = taskActivity.Task.Project.Account.TaxpayerIdentificationNumber,
                ProjectName = taskActivity.Task.Project.Name,
                AccountName = taskActivity.Task.Project.Account.Name
            }).ToList();

            return taViewModels;
        }
    }
}
