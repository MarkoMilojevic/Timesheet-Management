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
				config.CreateMap<AccountDTO, Account>();
				config.CreateMap<ProjectDTO, Project>();
				config.CreateMap<TaskDTO, Task>();
				config.CreateMap<TaskActivityDTO, TaskActivity>();
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
