using AutoMapper;
using TimesheetManagement.Data.EntityFramework.Entities;
using EmployeeDTO = TimesheetManagement.Data.Entities.Employee;
using ActivityDTO = TimesheetManagement.Data.Entities.Activity;
using AccountDTO = TimesheetManagement.Data.Tasks.Entities.Account;
using ProjectDTO = TimesheetManagement.Data.Tasks.Entities.Project;
using TaskDTO = TimesheetManagement.Data.Tasks.Entities.Task;
using TaskActivityDTO = TimesheetManagement.Data.Tasks.Entities.TaskActivity;

namespace TimesheetManagement.Data.EntityFramework.Common
{
	public static class EntityFrameworkAutoMapper
	{
		static EntityFrameworkAutoMapper()
		{
			Mapper.Initialize(config =>
			{
			    config.CreateMap<Employee, EmployeeDTO>();
                config.CreateMap<Activity, ActivityDTO>();
                config.CreateMap<Account, AccountDTO>();
				config.CreateMap<Project, ProjectDTO>();
				config.CreateMap<Task, TaskDTO>();
				config.CreateMap<TaskActivity, TaskActivityDTO>();
			});
		}

        public static EmployeeDTO CreateEmployee(Employee employee)
        {
            return Mapper.Map<Employee, EmployeeDTO>(employee);
        }

        public static ActivityDTO CreateActivity(Activity activity)
        {
            return Mapper.Map<Activity, ActivityDTO>(activity);
        }
        public static AccountDTO CreateAccount(Account account)
		{
            return Mapper.Map<Account, AccountDTO>(account);
        }

		public static ProjectDTO CreateProject(Project project)
		{
            //Throws Exception for Mapper.Map<ProjectDTO>(project);
            //Map<TSource, TDestination>(TSource source); vs Map<TDestination>(object source); 
            //Better to call generic method rather one casting to object

            //return Mapper.Map<Project, ProjectDTO>(project); Even this throws an exception often.

		    var projectDto = Mapper.Map<Project, ProjectDTO>(project);
		    return projectDto;

            //We will possibly have to quit using Automapper when transforming Entities to DTO's. We will have to write conversion methods manualy.
		}

		public static TaskDTO CreateTask(Task task)
		{
			var taskDto =  Mapper.Map<Task, TaskDTO>(task);
		    return taskDto;
		}

		public static TaskActivityDTO CreateTaskActivity(TaskActivity taskActivity)
		{
			var taskActivityDto =  Mapper.Map<TaskActivity, TaskActivityDTO>(taskActivity);
		    return taskActivityDto;
		}
	}
}
