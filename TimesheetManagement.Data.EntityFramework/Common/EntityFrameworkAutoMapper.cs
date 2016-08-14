using AutoMapper;
using TimesheetManagement.Data.EntityFramework.Entities;
using ActivityBO = TimesheetManagement.Business.Entities.Activity;
using ClientBO = TimesheetManagement.Business.Entities.Client;
using EmployeeBO = TimesheetManagement.Business.Entities.Employee;
using EmployeeActivityBO = TimesheetManagement.Business.Entities.EmployeeActivity;
using ProjectBO = TimesheetManagement.Business.Entities.Project;

namespace TimesheetManagement.Data.EntityFramework.Common
{
	public static class EntityFrameworkAutoMapper
	{
		static EntityFrameworkAutoMapper()
		{
			Mapper.Initialize(config =>
			{
				config.CreateMap<Client, ClientBO>();
				config.CreateMap<Project, ProjectBO>();
				config.CreateMap<Activity, ActivityBO>();
				config.CreateMap<Employee, EmployeeBO>();
				config.CreateMap<EmployeeActivity, EmployeeActivityBO>();
			});
		}

		public static ClientBO CreateClient(Client client)
		{
			return Mapper.Map<ClientBO>(client);
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
