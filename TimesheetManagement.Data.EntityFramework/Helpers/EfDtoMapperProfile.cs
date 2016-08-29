using AutoMapper;
using TimesheetManagement.Data.EntityFramework.Entities;
using EmployeeDTO = TimesheetManagement.Data.Entities.Employee;
using ActivityDTO = TimesheetManagement.Data.Entities.Activity;
using AccountDTO = TimesheetManagement.Data.Tasks.Entities.Account;
using ProjectDTO = TimesheetManagement.Data.Tasks.Entities.Project;
using TaskDTO = TimesheetManagement.Data.Tasks.Entities.Task;
using TaskActivityDTO = TimesheetManagement.Data.Tasks.Entities.TaskActivity;

namespace TimesheetManagement.Data.EntityFramework.Helpers
{
	public class EfDtoMapperProfile : Profile
	{
		public EfDtoMapperProfile()
		{
            this.CreateMap<Employee, EmployeeDTO>().MaxDepth(2);
            this.CreateMap<EmployeeDTO, Employee>().MaxDepth(2);

            this.CreateMap<Activity, ActivityDTO>().MaxDepth(2);
            this.CreateMap<ActivityDTO, Activity>().ForMember(dest => dest.Employee, opt => opt.Ignore())
                                                    .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.Employee.EmployeeId))
                                                    .MaxDepth(2);

            this.CreateMap<Account, AccountDTO>().MaxDepth(2);

            this.CreateMap<Project, ProjectDTO>().MaxDepth(2);
            this.CreateMap<ProjectDTO, Project>().ForMember(dest => dest.Account, opt => opt.Ignore())
                                                    .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.Account.TaxpayerIdentificationNumber))
                                                    .MaxDepth(2);

            this.CreateMap<Task, TaskDTO>().MaxDepth(2);
            this.CreateMap<TaskDTO, Task>().ForMember(dest => dest.Project, opt => opt.Ignore())
                                            .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.Project.ProjectId))
                                            .MaxDepth(2);

            this.CreateMap<TaskActivity, TaskActivityDTO>().MaxDepth(2);
            this.CreateMap<TaskActivityDTO, TaskActivity>().ForMember(dest => dest.ActivityId, opt => opt.MapFrom(src => src.Activity.ActivityId))
                                                            .ForMember(dest => dest.Task, opt => opt.Ignore())
                                                            .ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.Task.TaskId))
                                                            .MaxDepth(2);
        }
	}
}
