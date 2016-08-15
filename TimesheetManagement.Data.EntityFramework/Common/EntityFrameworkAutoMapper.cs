using AutoMapper;
using TimesheetManagement.Data.EntityFramework.Entities;
using ActivityBO = TimesheetManagement.Business.Tasks.Entities.Activity;
using AccountBO = TimesheetManagement.Business.Tasks.Entities.Account;
using EmployeeBO = TimesheetManagement.Business.Tasks.Entities.Employee;
using EmployeeActivityBO = TimesheetManagement.Business.Tasks.Entities.EmployeeActivity;
using ProjectBO = TimesheetManagement.Business.Tasks.Entities.Project;

namespace TimesheetManagement.Data.EntityFramework.Common
{
	public static class EntityFrameworkAutoMapper
	{
		static EntityFrameworkAutoMapper()
		{
			Mapper.Initialize(config =>
			{
				config.CreateMap<Account, AccountBO>();
				config.CreateMap<Project, ProjectBO>();
				config.CreateMap<Activity, ActivityBO>();
				config.CreateMap<Employee, EmployeeBO>();
				config.CreateMap<EmployeeActivity, EmployeeActivityBO>();
			});
		}

		public static AccountBO CreateClient(Account client)
		{
			return Mapper.Map<AccountBO>(client);
		}

		public static ProjectBO CreateProject(Project project)
		{
			return Mapper.Map<ProjectBO>(project);
		}

		public static ActivityBO CreateActivity(Activity activity)
		{
			return Mapper.Map<ActivityBO>(activity);
		}

		public static EmployeeBO CreateEmployee(Employee employee)
		{
			return Mapper.Map<EmployeeBO>(employee);
		}

		public static EmployeeActivityBO CreateEmployeeActivity(EmployeeActivity employeeActivity)
		{
			return Mapper.Map<EmployeeActivityBO>(employeeActivity);
		}
	}
}
