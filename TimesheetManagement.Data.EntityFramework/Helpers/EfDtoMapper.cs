using AutoMapper;
using TimesheetManagement.Data.EntityFramework.Entities;
using EmployeeDTO = TimesheetManagement.Data.Entities.Employee;
using ActivityDTO = TimesheetManagement.Data.Entities.Activity;
using AccountDTO = TimesheetManagement.Data.Tasks.Entities.Account;
using ProjectDTO = TimesheetManagement.Data.Tasks.Entities.Project;
using TaskDTO = TimesheetManagement.Data.Tasks.Entities.Task;
using TaskActivityDTO = TimesheetManagement.Data.Tasks.Entities.TaskActivity;

namespace TimesheetManagement.Data.EntityFramework.Helpers
{
	public static class EfDtoMapper
	{
		private static readonly IMapper Mapper;

		static EfDtoMapper()
		{
			MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddProfile<EfDtoMapperProfile>());
			EfDtoMapper.Mapper = config.CreateMapper();
		}

		public static EmployeeDTO CreateEmployeeDto(Employee employee)
		{
			return EfDtoMapper.Mapper.Map<Employee, EmployeeDTO>(employee);
		}

		public static ActivityDTO CreateActivityDto(Activity activity)
		{
			return EfDtoMapper.Mapper.Map<Activity, ActivityDTO>(activity);
		}

        public static Activity CreateActivity(ActivityDTO activity)
        {
            return EfDtoMapper.Mapper.Map<ActivityDTO, Activity>(activity);
        }

        public static AccountDTO CreateAccountDto(Account account)
		{
			return EfDtoMapper.Mapper.Map<Account, AccountDTO>(account);
		}

		public static ProjectDTO CreateProjectDto(Project project)
		{
			return EfDtoMapper.Mapper.Map<Project, ProjectDTO>(project);
		}

		public static TaskDTO CreateTaskDto(Task task)
		{
			return EfDtoMapper.Mapper.Map<Task, TaskDTO>(task);
		}

		public static TaskActivityDTO CreateTaskActivityDto(TaskActivity taskActivity)
		{
			return EfDtoMapper.Mapper.Map<TaskActivity, TaskActivityDTO>(taskActivity);
		}

        public static TaskActivity CreateTaskActivity(TaskActivityDTO taskActivity)
        {
            return EfDtoMapper.Mapper.Map<TaskActivityDTO, TaskActivity>(taskActivity);
        }
    }
}
