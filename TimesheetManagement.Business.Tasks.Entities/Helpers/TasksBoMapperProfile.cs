using AutoMapper;
using TimesheetManagement.Business.Entities;
using TimesheetManagement.Business.Tasks.Entities;
using EmployeeDTO = TimesheetManagement.Data.Entities.Employee;
using ActivityDTO = TimesheetManagement.Data.Entities.Activity;
using AccountDTO = TimesheetManagement.Data.Tasks.Entities.Account;
using ProjectDTO = TimesheetManagement.Data.Tasks.Entities.Project;
using TaskDTO = TimesheetManagement.Data.Tasks.Entities.Task;
using TaskActivityDTO = TimesheetManagement.Data.Tasks.Entities.TaskActivity;

namespace TimesheetManagement.Business.Tasks.Helpers
{
    public class TasksBoMapperProfile : Profile
	{
		public TasksBoMapperProfile()
		{
            this.CreateMap<EmployeeDTO, Employee>().MaxDepth(2);
            this.CreateMap<Employee, EmployeeDTO>().MaxDepth(2);

            this.CreateMap<ActivityDTO, Activity>().ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.Employee.EmployeeId))
                                                    .MaxDepth(2);
            this.CreateMap<Activity, ActivityDTO>().ForMember(dest => dest.Employee, opt => opt.MapFrom(src => new EmployeeDTO { EmployeeId = src.EmployeeId }))
                                                    .MaxDepth(2);

            this.CreateMap<AccountDTO, Account>().MaxDepth(2);
            this.CreateMap<Account, AccountDTO>().MaxDepth(2);

            this.CreateMap<ProjectDTO, Project>().ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.Account.TaxpayerIdentificationNumber))
                                                    .MaxDepth(2);
            this.CreateMap<Project, ProjectDTO>().ForMember(dest => dest.Account, opt => opt.MapFrom(src => new AccountDTO { TaxpayerIdentificationNumber = src.AccountId }))
                                                    .MaxDepth(2);

            this.CreateMap<TaskDTO, Task>().ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.Project.ProjectId))
                                            .MaxDepth(2);
		    this.CreateMap<Task, TaskDTO>().ForMember(dest => dest.Project, opt => opt.MapFrom(src => new ProjectDTO { ProjectId = src.ProjectId }))
                                            .MaxDepth(2);

            this.CreateMap<TaskActivityDTO, TaskActivity>().ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.Task.TaskId))
                                                            .MaxDepth(2);
            this.CreateMap<TaskActivity, TaskActivityDTO>().ForMember(dest => dest.Task, opt => opt.MapFrom(src => new TaskDTO { TaskId = src.TaskId }))
                                                            .MaxDepth(2);
        }
	}
}
