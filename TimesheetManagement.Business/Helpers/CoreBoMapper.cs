using AutoMapper;
using TimesheetManagement.Business.Entities;
using EmployeeDTO = TimesheetManagement.Data.Entities.Employee;
using ActivityDTO = TimesheetManagement.Data.Entities.Activity;

namespace TimesheetManagement.Business.Helpers
{
    public static class CoreBoMapper
    {
        private static readonly IMapper Mapper;

        static CoreBoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddProfile<CoreBoMapperProfile>());
            Mapper = config.CreateMapper();
        }

        public static Employee CreateEmployee(EmployeeDTO employee)
        {
            return Mapper.Map<EmployeeDTO, Employee>(employee);
        }

        public static EmployeeDTO CreateEmployeeDto(Employee employee)
        {
            return Mapper.Map<Employee, EmployeeDTO>(employee);
        }

        public static Activity CreateActivity(ActivityDTO activity)
        {
            return Mapper.Map<ActivityDTO, Activity>(activity);
        }

        public static ActivityDTO CreateActivityDto(Activity activity)
        {
            return Mapper.Map<Activity, ActivityDTO>(activity);
        }
    }
}