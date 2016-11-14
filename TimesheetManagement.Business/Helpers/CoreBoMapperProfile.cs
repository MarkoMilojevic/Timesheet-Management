using AutoMapper;
using TimesheetManagement.Business.Entities;
using EmployeeDTO = TimesheetManagement.Data.Entities.Employee;
using ActivityDTO = TimesheetManagement.Data.Entities.Activity;

namespace TimesheetManagement.Business.Helpers
{
    public class CoreBoMapperProfile : Profile
    {
        public CoreBoMapperProfile()
        {
            CreateMap<EmployeeDTO, Employee>().MaxDepth(2);
            CreateMap<Employee, EmployeeDTO>().MaxDepth(2);

            CreateMap<ActivityDTO, Activity>().MaxDepth(2);
            CreateMap<Activity, ActivityDTO>().MaxDepth(2);
        }
    }
}