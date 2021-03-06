﻿using AutoMapper;
using TimesheetManagement.Data.EntityFramework.Entities;
using EmployeeDTO = TimesheetManagement.Data.Entities.Employee;
using ActivityDTO = TimesheetManagement.Data.Entities.Activity;
using ClientDTO = TimesheetManagement.Data.Tasks.Entities.Client;
using ProjectDTO = TimesheetManagement.Data.Tasks.Entities.Project;
using TaskDTO = TimesheetManagement.Data.Tasks.Entities.Task;
using TaskActivityDTO = TimesheetManagement.Data.Tasks.Entities.TaskActivity;

namespace TimesheetManagement.Data.EntityFramework.Helpers
{
    public class EfDtoMapperProfile : Profile
    {
        public EfDtoMapperProfile()
        {
            CreateMap<Employee, EmployeeDTO>().MaxDepth(2);
            CreateMap<EmployeeDTO, Employee>().MaxDepth(2);

            CreateMap<Activity, ActivityDTO>().MaxDepth(2);
            CreateMap<ActivityDTO, Activity>().ForMember(dest => dest.Employee, opt => opt.Ignore())
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.Employee.EmployeeId))
                .MaxDepth(2);

            CreateMap<Client, ClientDTO>().MaxDepth(2);
            CreateMap<ClientDTO, Client>().MaxDepth(2);

            CreateMap<Project, ProjectDTO>().MaxDepth(2);
            CreateMap<ProjectDTO, Project>().ForMember(dest => dest.Client, opt => opt.Ignore())
                .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.Client.TaxpayerIdentificationNumber))
                .MaxDepth(2);

            CreateMap<Task, TaskDTO>().MaxDepth(2);
            CreateMap<TaskDTO, Task>().ForMember(dest => dest.Project, opt => opt.Ignore())
                .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.Project.ProjectId))
                .MaxDepth(2);

            CreateMap<TaskActivity, TaskActivityDTO>().MaxDepth(2);
            CreateMap<TaskActivityDTO, TaskActivity>().ForMember(dest => dest.ActivityId, opt => opt.MapFrom(src => src.Activity.ActivityId))
                .ForMember(dest => dest.Task, opt => opt.Ignore())
                .ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.Task.TaskId))
                .MaxDepth(2);
        }
    }
}
