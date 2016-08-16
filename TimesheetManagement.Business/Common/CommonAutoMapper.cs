using AutoMapper;
using TimesheetManagement.Business.Entities;
using EmployeeDTO = TimesheetManagement.Data.Entities.Employee;
using ActivityDTO = TimesheetManagement.Data.Entities.Activity;

namespace TimesheetManagement.Business.Common
{
	public static class CommonAutoMapper
	{
		static CommonAutoMapper()
		{
			Mapper.Initialize(config =>
			{
				config.CreateMap<EmployeeDTO, Employee>();
				config.CreateMap<ActivityDTO, Activity>();
			});
		}

		public static Employee CreateEmployee(EmployeeDTO employee)
		{
			return Mapper.Map<Employee>(employee);
		}

		public static Activity CreateActivity(ActivityDTO activity)
		{
			return Mapper.Map<Activity>(activity);
		}
	}
}
