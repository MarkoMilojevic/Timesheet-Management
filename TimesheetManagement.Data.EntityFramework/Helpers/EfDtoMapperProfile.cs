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
			this.CreateMap<Activity, ActivityDTO>().MaxDepth(2);
			this.CreateMap<Account, AccountDTO>().MaxDepth(2);
			this.CreateMap<Project, ProjectDTO>().MaxDepth(2);
			this.CreateMap<Task, TaskDTO>().MaxDepth(2);
			this.CreateMap<TaskActivity, TaskActivityDTO>().MaxDepth(2);
		}
	}
}
