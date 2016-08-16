using AutoMapper;
using TimesheetManagement.Data.EntityFramework.Entities;
using EmployeeDTO = TimesheetManagement.Data.Entities.Employee;
using ActivityDTO = TimesheetManagement.Data.Entities.Activity;
using AccountDTO = TimesheetManagement.Data.Tasks.Entities.Account;
using ProjectDTO = TimesheetManagement.Data.Tasks.Entities.Project;
using TaskDTO = TimesheetManagement.Data.Tasks.Entities.Task;
using TaskActivityDTO = TimesheetManagement.Data.Tasks.Entities.TaskActivity;

namespace TimesheetManagement.Data.EntityFramework.Common
{
	public static class EntityFrameworkAutoMapper
	{
		static EntityFrameworkAutoMapper()
		{
			Mapper.Initialize(config =>
			{
                config.CreateMap<Employee, EmployeeDTO>();
                config.CreateMap<Activity, ActivityDTO>();
                config.CreateMap<Account, AccountDTO>();
				config.CreateMap<Project, ProjectDTO>();
				config.CreateMap<Task, TaskDTO>();
				config.CreateMap<TaskActivity, TaskActivityDTO>();
			});
		}

        public static EmployeeDTO CreateEmployee(Employee employee)
        {
            return Mapper.Map<EmployeeDTO>(employee);
        }

        public static ActivityDTO CreateActivity(Activity activity)
        {
            return Mapper.Map<ActivityDTO>(activity);
        }
        public static AccountDTO CreateAccount(Account account)
		{
			return Mapper.Map<AccountDTO>(account);
		}

		public static ProjectDTO CreateProject(Project project)
		{
			return Mapper.Map<ProjectDTO>(project);
		}

		public static TaskDTO CreateTask(Task task)
		{
			return Mapper.Map<TaskDTO>(task);
		}

		public static TaskActivityDTO CreateTaskActivity(TaskActivity taskActivity)
		{
			return Mapper.Map<TaskActivityDTO>(taskActivity);
		}
	}
}
