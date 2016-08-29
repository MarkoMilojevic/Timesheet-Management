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
using TimesheetManagement.Business.Tasks.Helpers;

namespace TimesheetManagement.Business.Tasks.Managers
{
    public class TasksManager : ITasksManager
    {
        private readonly IActivityRepository activityRepository;
        private readonly ITaskRepository tasksRepository;

        public TasksManager(IActivityRepository activityRepository, ITaskRepository taskRepository)
        {
            this.activityRepository = activityRepository;
            this.tasksRepository = taskRepository;
        }
        
        public Account GetAccount(string accoundId)
        {
            AccountDTO account = tasksRepository.GetAccount(accoundId);

            return TasksBoMapper.CreateAccount(account);
        }

        public ICollection<Account> GetAccounts()
        {
            ICollection<AccountDTO> clients = tasksRepository.GetAccounts();

            return clients.Select(TasksBoMapper.CreateAccount).ToList();
        }

        public Project GetProject(int projectId)
        {
            ProjectDTO project = tasksRepository.GetProject(projectId);

            return TasksBoMapper.CreateProject(project);
        }

        public ICollection<Project> GetProjects(string accoundId)
        {
            ICollection<ProjectDTO> projects = tasksRepository.GetProjects(accoundId);
            return projects.Select(TasksBoMapper.CreateProject).ToList();
        }
        
        public Task GetTask(int taskId)
        {
            TaskDTO task = tasksRepository.GetTask(taskId);

            return TasksBoMapper.CreateTask(task);
        }

        public ICollection<Task> GetTasks(int projectId)
        {
            ICollection<TaskDTO> tasks = tasksRepository.GetTasks(projectId);

            return tasks.Select(TasksBoMapper.CreateTask).ToList();
        }

        public ICollection<TaskActivityViewModel> GetTaskActivities(int employeeId)
        {
            ICollection<TaskActivityDTO> taskActivities = tasksRepository.GetTaskActivities(employeeId);
            ICollection<TaskActivityViewModel> taViewModels = taskActivities.Select(taskActivity => new TaskActivityViewModel
            {
                AccountId = taskActivity.Task.Project.Account.TaxpayerIdentificationNumber,
                AccountName = taskActivity.Task.Project.Account.Name,
                ProjectId = taskActivity.Task.Project.ProjectId,
                ProjectName = taskActivity.Task.Project.Name,
                TaskId = taskActivity.Task.TaskId,
                TaskName = taskActivity.Task.Name,
                Activity = CommonBoMapper.CreateActivity(taskActivity.Activity),
            }).ToList();

            return taViewModels;
        }

        public void CreateTaskActivity(TaskActivity taskActivity)
        {
            this.tasksRepository.CreateTaskActivity(TasksBoMapper.CreateTaskActivityDto(taskActivity));
        }
    }
}
