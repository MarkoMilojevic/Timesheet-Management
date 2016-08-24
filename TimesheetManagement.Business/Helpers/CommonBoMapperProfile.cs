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
			this.CreateMap<ActivityDTO, Activity>().MaxDepth(2).ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.Employee.EmployeeId));
		}
	}
}
