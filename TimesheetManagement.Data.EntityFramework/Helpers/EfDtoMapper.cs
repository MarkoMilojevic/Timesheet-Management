using AutoMapper;
using TimesheetManagement.Data.EntityFramework.Entities;
using EmployeeDTO = TimesheetManagement.Data.Entities.Employee;
using ActivityDTO = TimesheetManagement.Data.Entities.Activity;
using ClientDTO = TimesheetManagement.Data.Tasks.Entities.Client;
using ProjectDTO = TimesheetManagement.Data.Tasks.Entities.Project;
using TaskDTO = TimesheetManagement.Data.Tasks.Entities.Task;
using TaskActivityDTO = TimesheetManagement.Data.Tasks.Entities.TaskActivity;

namespace TimesheetManagement.Data.EntityFramework.Helpers
{
    public static class EfDtoMapper
    {
        private static readonly IMapper Mapper;

        static EfDtoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddProfile<EfDtoMapperProfile>());
            Mapper = config.CreateMapper();
        }

        public static EmployeeDTO CreateEmployeeDto(Employee employee)
        {
            return Mapper.Map<Employee, EmployeeDTO>(employee);
        }

        public static Employee CreateEmployee(EmployeeDTO employeeDto)
        {
            return Mapper.Map<EmployeeDTO, Employee>(employeeDto);
        }

        public static ActivityDTO CreateActivityDto(Activity activity)
        {
            return Mapper.Map<Activity, ActivityDTO>(activity);
        }

        public static Activity CreateActivity(ActivityDTO activity)
        {
            return Mapper.Map<ActivityDTO, Activity>(activity);
        }

        public static ClientDTO CreateClientDto(Client client)
        {
            return Mapper.Map<Client, ClientDTO>(client);
        }

        public static Client CreateClient(ClientDTO clientDto)
        {
            return Mapper.Map<ClientDTO, Client>(clientDto);
        }

        public static ProjectDTO CreateProjectDto(Project project)
        {
            return Mapper.Map<Project, ProjectDTO>(project);
        }

        public static Project CreateProject(ProjectDTO project)
        {
            return Mapper.Map<ProjectDTO, Project>(project);
        }

        public static TaskDTO CreateTaskDto(Task task)
        {
            return Mapper.Map<Task, TaskDTO>(task);
        }

        public static Task CreateTask(TaskDTO taskDto)
        {
            return Mapper.Map<TaskDTO, Task>(taskDto);
        }

        public static TaskActivityDTO CreateTaskActivityDto(TaskActivity taskActivity)
        {
            return Mapper.Map<TaskActivity, TaskActivityDTO>(taskActivity);
        }

        public static TaskActivity CreateTaskActivity(TaskActivityDTO taskActivity)
        {
            return Mapper.Map<TaskActivityDTO, TaskActivity>(taskActivity);
        }
    }
}
