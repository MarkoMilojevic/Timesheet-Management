using AutoMapper;
using TimesheetManagement.Data.EntityFramework.Entities;
using EmployeeBO = TimesheetManagement.Business.Entities.Employee;
using ActivityBO = TimesheetManagement.Business.Entities.Activity;
using AccountBO = TimesheetManagement.Business.Tasks.Entities.Account;
using ProjectBO = TimesheetManagement.Business.Tasks.Entities.Project;
using TaskBO = TimesheetManagement.Business.Tasks.Entities.Task;
using TaskActivityBO = TimesheetManagement.Business.Tasks.Entities.TaskActivity;

namespace TimesheetManagement.Data.EntityFramework.Common
{
	public static class EntityFrameworkAutoMapper
	{
		static EntityFrameworkAutoMapper()
		{
			Mapper.Initialize(config =>
			{
				config.CreateMap<Employee, EmployeeBO>();
				config.CreateMap<Activity, ActivityBO>();
				config.CreateMap<Account, AccountBO>();
				config.CreateMap<Project, ProjectBO>();
				config.CreateMap<Task, TaskBO>();
				config.CreateMap<TaskActivity, TaskActivityBO>();
			});
		}

		public static EmployeeBO CreateEmployee(Employee employee)
		{
			return Mapper.Map<EmployeeBO>(employee);
		}

		public static ActivityBO CreateActivity(Activity activity)
		{
			return Mapper.Map<ActivityBO>(activity);
		}

		public static AccountBO CreateAccount(Account client)
		{
			return Mapper.Map<AccountBO>(client);
		}

		public static ProjectBO CreateProject(Project project)
		{
			return Mapper.Map<ProjectBO>(project);
		}

		public static TaskBO CreateTask(Task task)
		{
			return Mapper.Map<TaskBO>(task);
		}

		public static TaskActivityBO CreateTaskActivity(TaskActivity taskActivity)
		{
			return Mapper.Map<TaskActivityBO>(taskActivity);
		}
	}
}
