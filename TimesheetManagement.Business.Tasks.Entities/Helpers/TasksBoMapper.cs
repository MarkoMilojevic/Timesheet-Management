using AutoMapper;
using TimesheetManagement.Business.Tasks.Entities;
using ClientDTO = TimesheetManagement.Data.Tasks.Entities.Client;
using ProjectDTO = TimesheetManagement.Data.Tasks.Entities.Project;
using TaskDTO = TimesheetManagement.Data.Tasks.Entities.Task;
using TaskActivityDTO = TimesheetManagement.Data.Tasks.Entities.TaskActivity;

namespace TimesheetManagement.Business.Tasks.Helpers
{
    public static class TasksBoMapper
    {
        private static readonly IMapper Mapper;

        static TasksBoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddProfile<TasksBoMapperProfile>());
            Mapper = config.CreateMapper();
        }

        public static Client CreateClient(ClientDTO clientDto)
        {
            return Mapper.Map<ClientDTO, Client>(clientDto);
        }

        public static ClientDTO CreateClientDto(Client client)
        {
            return Mapper.Map<Client, ClientDTO>(client);
        }

        public static Project CreateProject(ProjectDTO projectDto)
        {
            return Mapper.Map<ProjectDTO, Project>(projectDto);
        }

        public static ProjectDTO CreateProjectDto(Project project)
        {
            return Mapper.Map<Project, ProjectDTO>(project);
        }

        public static Task CreateTask(TaskDTO taskDto)
        {
            return Mapper.Map<TaskDTO, Task>(taskDto);
        }

        public static TaskDTO CreateTaskDto(Task task)
        {
            return Mapper.Map<Task, TaskDTO>(task);
        }

        public static TaskActivity CreateTaskActivity(TaskActivityDTO taskActivityDto)
        {
            return Mapper.Map<TaskActivityDTO, TaskActivity>(taskActivityDto);
        }

        public static TaskActivityDTO CreateTaskActivityDto(TaskActivity taskActivity)
        {
            return Mapper.Map<TaskActivity, TaskActivityDTO>(taskActivity);
        }
    }
}