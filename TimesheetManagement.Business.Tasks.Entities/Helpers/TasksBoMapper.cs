using AutoMapper;
using TimesheetManagement.Business.Tasks.Entities;
using AccountDTO = TimesheetManagement.Data.Tasks.Entities.Account;
using ProjectDTO = TimesheetManagement.Data.Tasks.Entities.Project;
using TaskDTO = TimesheetManagement.Data.Tasks.Entities.Task;

namespace TimesheetManagement.Business.Tasks.Helpers
{
	public static class TasksBoMapper
	{
		private static readonly IMapper Mapper;

		static TasksBoMapper()
		{
			MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddProfile<TasksBoMapperProfile>());
			TasksBoMapper.Mapper = config.CreateMapper();
		}

		public static Account CreateAccount(AccountDTO account)
		{
			return TasksBoMapper.Mapper.Map<Account>(account);
		}

		public static Project CreateProject(ProjectDTO project)
		{
			return TasksBoMapper.Mapper.Map<Project>(project);
		}

		public static Task CreateTask(TaskDTO task)
		{
			return TasksBoMapper.Mapper.Map<Task>(task);
		}
	}
}
