using AutoMapper;
using TimesheetManagement.Business.Entities;
using TimesheetManagement.Business.Tasks.Entities;
using EmployeeDTO = TimesheetManagement.Data.Entities.Employee;
using ActivityDTO = TimesheetManagement.Data.Entities.Activity;
using ClientDTO = TimesheetManagement.Data.Tasks.Entities.Client;
using ProjectDTO = TimesheetManagement.Data.Tasks.Entities.Project;
using TaskDTO = TimesheetManagement.Data.Tasks.Entities.Task;
using TaskActivityDTO = TimesheetManagement.Data.Tasks.Entities.TaskActivity;

namespace TimesheetManagement.Business.Tasks.Helpers
{
    public class TasksBoMapperProfile : Profile
    {
        public TasksBoMapperProfile()
        {
            CreateMap<EmployeeDTO, Employee>().MaxDepth(2);
            CreateMap<Employee, EmployeeDTO>().MaxDepth(2);

            CreateMap<ActivityDTO, Activity>().MaxDepth(2);
            CreateMap<Activity, ActivityDTO>().MaxDepth(2);

            CreateMap<ClientDTO, Client>().MaxDepth(2);
            CreateMap<Client, ClientDTO>().MaxDepth(2);

            CreateMap<ProjectDTO, Project>().MaxDepth(2);
            CreateMap<Project, ProjectDTO>().MaxDepth(2);

            CreateMap<TaskDTO, Task>().MaxDepth(2);
            CreateMap<Task, TaskDTO>().MaxDepth(2);

            CreateMap<TaskActivityDTO, TaskActivity>().MaxDepth(2);
            CreateMap<TaskActivity, TaskActivityDTO>().MaxDepth(2);
        }
    }
}