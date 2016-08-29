using AutoMapper;
using TimesheetManagement.Business.Entities;
using EmployeeDTO = TimesheetManagement.Data.Entities.Employee;
using ActivityDTO = TimesheetManagement.Data.Entities.Activity;

namespace TimesheetManagement.Business.Helpers
{
	public class CommonBoMapperProfile : Profile
	{
	    public CommonBoMapperProfile()
	    {
	        this.CreateMap<EmployeeDTO, Employee>().MaxDepth(2);
	        this.CreateMap<Employee, EmployeeDTO>().MaxDepth(2);

	        this.CreateMap<ActivityDTO, Activity>().ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.Employee.EmployeeId))
                                                    .MaxDepth(2);
	        this.CreateMap<Activity, ActivityDTO>().ForMember(dest => dest.Employee, opt => opt.MapFrom(src => new EmployeeDTO {  EmployeeId = src.EmployeeId } ))
                                                    .MaxDepth(2);
		}
	}
}
