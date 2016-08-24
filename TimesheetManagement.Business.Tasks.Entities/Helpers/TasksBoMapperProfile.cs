using AutoMapper;
using TimesheetManagement.Business.Tasks.Entities;
using AccountDTO = TimesheetManagement.Data.Tasks.Entities.Account;
using ProjectDTO = TimesheetManagement.Data.Tasks.Entities.Project;
using TaskDTO = TimesheetManagement.Data.Tasks.Entities.Task;

namespace TimesheetManagement.Business.Tasks.Helpers
{
    public class TasksBoMapperProfile : Profile
	{
		public TasksBoMapperProfile()
		{
			this.CreateMap<AccountDTO, Account>().MaxDepth(2);
			this.CreateMap<ProjectDTO, Project>().MaxDepth(2).ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.Account.TaxpayerIdentificationNumber));
			this.CreateMap<TaskDTO, Task>().MaxDepth(2).ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.Project.ProjectId));
        }
	}
}
