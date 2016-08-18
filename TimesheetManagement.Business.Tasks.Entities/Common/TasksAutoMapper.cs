using AutoMapper;
using TimesheetManagement.Business.Tasks.Entities;
using AccountDTO = TimesheetManagement.Data.Tasks.Entities.Account;
using ProjectDTO = TimesheetManagement.Data.Tasks.Entities.Project;
using TaskDTO = TimesheetManagement.Data.Tasks.Entities.Task;
using TaskActivityDTO = TimesheetManagement.Data.Tasks.Entities.TaskActivity;

namespace TimesheetManagement.Business.Tasks.Common
{
	public static class TasksAutoMapper
	{
		static TasksAutoMapper()
		{
			Mapper.Initialize(config =>
			{
			    config.CreateMap<AccountDTO, Account>().MaxDepth(3);
				config.CreateMap<ProjectDTO, Project>().MaxDepth(3);
				config.CreateMap<TaskDTO, Task>().MaxDepth(3);
				config.CreateMap<TaskActivityDTO, TaskActivity>().MaxDepth(3);
			});
		}
        
		public static Account CreateAccount(AccountDTO account)
		{
			return Mapper.Map<Account>(account);
		}

		public static Project CreateProject(ProjectDTO project)
		{
			return Mapper.Map<Project>(project);
		}

		public static Task CreateTask(TaskDTO task)
		{
			return Mapper.Map<Task>(task);
		}

		public static TaskActivity CreateTaskActivity(TaskActivityDTO taskActivity)
		{
			return Mapper.Map<TaskActivity>(taskActivity);
		}
	}
}
