using AutoMapper;
using TimesheetManagement.Business.Entities;
using EmployeeDTO = TimesheetManagement.Data.Entities.Employee;
using ActivityDTO = TimesheetManagement.Data.Entities.Activity;

namespace TimesheetManagement.Business.Helpers
{
	public static class CommonBoMapper
	{
		private static readonly IMapper Mapper;

		static CommonBoMapper()
		{
			MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddProfile<CommonBoMapperProfile>());
			CommonBoMapper.Mapper = config.CreateMapper();
		}

		public static Employee CreateEmployee(EmployeeDTO employee)
		{
			return CommonBoMapper.Mapper.Map<EmployeeDTO, Employee>(employee);
		}

        public static EmployeeDTO CreateEmployeeDto(Employee employee)
        {
            return CommonBoMapper.Mapper.Map<Employee, EmployeeDTO>(employee);
        }

        public static Activity CreateActivity(ActivityDTO activity)
		{
			return CommonBoMapper.Mapper.Map<ActivityDTO, Activity>(activity);
		}

	    public static ActivityDTO CreateActivityDto(Activity activity)
	    {
            return CommonBoMapper.Mapper.Map<Activity, ActivityDTO>(activity);
        }
    }
}
