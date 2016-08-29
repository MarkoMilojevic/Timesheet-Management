﻿using AutoMapper;
using TimesheetManagement.Business.Tasks.Entities;
using AccountDTO = TimesheetManagement.Data.Tasks.Entities.Account;
using ProjectDTO = TimesheetManagement.Data.Tasks.Entities.Project;
using TaskDTO = TimesheetManagement.Data.Tasks.Entities.Task;
using TaskActivityDTO = TimesheetManagement.Data.Tasks.Entities.TaskActivity;

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
			return TasksBoMapper.Mapper.Map<AccountDTO, Account>(account);
		}

		public static Project CreateProject(ProjectDTO project)
		{
			return TasksBoMapper.Mapper.Map<ProjectDTO, Project>(project);
		}

		public static Task CreateTask(TaskDTO task)
		{
			return TasksBoMapper.Mapper.Map<TaskDTO, Task>(task);
		}

        public static TaskActivityDTO CreateTaskActivityDto(TaskActivity taskActivity)
        {
            return TasksBoMapper.Mapper.Map<TaskActivity, TaskActivityDTO>(taskActivity);
        }
    }
}
