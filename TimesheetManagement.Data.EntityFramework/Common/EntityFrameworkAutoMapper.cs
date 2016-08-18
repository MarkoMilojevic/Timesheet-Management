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
			    config.CreateMap<Employee, EmployeeDTO>().MaxDepth(3);
                config.CreateMap<Activity, ActivityDTO>().MaxDepth(3);
			    config.CreateMap<Account, AccountDTO>().MaxDepth(3);
				config.CreateMap<Project, ProjectDTO>().MaxDepth(3);
                config.CreateMap<Task, TaskDTO>().MaxDepth(3);
				config.CreateMap<TaskActivity, TaskActivityDTO>().MaxDepth(3);
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
            return Mapper.Map<AccountDTO>(account);
        }

		public static ProjectDTO CreateProject(Project project)
		{
            ProjectDTO projectDto = Mapper.Map<Project, ProjectDTO>(project);
		    return projectDto;
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
