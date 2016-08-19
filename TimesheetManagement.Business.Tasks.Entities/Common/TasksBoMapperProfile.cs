using AutoMapper;
using TimesheetManagement.Business.Tasks.Entities;
using AccountDTO = TimesheetManagement.Data.Tasks.Entities.Account;
using ProjectDTO = TimesheetManagement.Data.Tasks.Entities.Project;
using TaskDTO = TimesheetManagement.Data.Tasks.Entities.Task;
using TaskActivityDTO = TimesheetManagement.Data.Tasks.Entities.TaskActivity;

namespace TimesheetManagement.Business.Tasks.Common
{
    public class TasksBoMapperProfile : Profile
    {
        public TasksBoMapperProfile()
        {
            CreateMap<AccountDTO, Account>().MaxDepth(2);
            CreateMap<ProjectDTO, Project>().MaxDepth(2);
            CreateMap<TaskDTO, Task>().MaxDepth(2);
            CreateMap<TaskActivityDTO, TaskActivity>().MaxDepth(2);
        }
    }
}
