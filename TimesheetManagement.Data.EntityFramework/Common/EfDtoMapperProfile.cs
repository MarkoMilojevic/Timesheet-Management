﻿using AutoMapper;
using TimesheetManagement.Data.EntityFramework.Entities;
using EmployeeDTO = TimesheetManagement.Data.Entities.Employee;
using ActivityDTO = TimesheetManagement.Data.Entities.Activity;
using AccountDTO = TimesheetManagement.Data.Tasks.Entities.Account;
using ProjectDTO = TimesheetManagement.Data.Tasks.Entities.Project;
using TaskDTO = TimesheetManagement.Data.Tasks.Entities.Task;
using TaskActivityDTO = TimesheetManagement.Data.Tasks.Entities.TaskActivity;

namespace TimesheetManagement.Data.EntityFramework.Common
{
    public class EfDtoMapperProfile : Profile
    {
        public EfDtoMapperProfile()
        {
            CreateMap<Employee, EmployeeDTO>().MaxDepth(2);
            CreateMap<Activity, ActivityDTO>().MaxDepth(2);
            CreateMap<Account, AccountDTO>().MaxDepth(2);
            CreateMap<Project, ProjectDTO>().MaxDepth(2);
            CreateMap<Task, TaskDTO>().MaxDepth(2);
            CreateMap<TaskActivity, TaskActivityDTO>().MaxDepth(2);
        }
    }
}
