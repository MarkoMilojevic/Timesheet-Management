using AutoMapper;
using TimesheetManagement.Data.EntityFramework.Entities;
using ActivityDTO = TimesheetManagement.Business.DataContracts.Activity;
using ClientDTO = TimesheetManagement.Business.DataContracts.Client;
using EmployeeDTO = TimesheetManagement.Business.DataContracts.Employee;
using EmployeeActivityDTO = TimesheetManagement.Business.DataContracts.EmployeeActivity;
using ProjectDTO = TimesheetManagement.Business.DataContracts.Project;

namespace TimesheetManagement.Data.EntityFramework.Common
{
    public static class EntityFrameworkAutoMapper
    {
        static EntityFrameworkAutoMapper()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Client, ClientDTO>();
                config.CreateMap<Project, ProjectDTO>();
                config.CreateMap<Activity, ActivityDTO>();
                config.CreateMap<Employee, EmployeeDTO>();
                config.CreateMap<EmployeeActivity, EmployeeActivityDTO>();
            });
        }

        public static ClientDTO CreateClient(Client client)
        {
            return Mapper.Map<ClientDTO>(client);
        }

        public static ProjectDTO CreateProject(Project project)
        {
            return Mapper.Map<ProjectDTO>(project);
        }

        public static ActivityDTO CreateActivity(Activity activity)
        {
            return Mapper.Map<ActivityDTO>(activity);
        }

        public static EmployeeDTO CreateEmployee(Employee employee)
        {
            return Mapper.Map<EmployeeDTO>(employee);
        }

        public static EmployeeActivityDTO CreateEmployeeActivity(EmployeeActivity employeeActivity)
        {
            return Mapper.Map<EmployeeActivityDTO>(employeeActivity);
        }
    }
}