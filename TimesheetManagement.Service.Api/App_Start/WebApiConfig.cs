using System.Net.Http.Headers;
using System.Web.Http;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TimesheetManagement.Business.Entities;
using TimesheetManagement.Business.Interfaces;
using TimesheetManagement.Business.Managers;
using TimesheetManagement.Business.Tasks.Entities;
using TimesheetManagement.Business.Tasks.Managers;
using TimesheetManagement.Data.EntityFramework.Repositories;
using TimesheetManagement.Data.Interfaces;
using TimesheetManagement.Service.Api.Helpers;
using ActivityDTO = TimesheetManagement.Data.Entities.Activity;
using EmployeeDTO = TimesheetManagement.Data.Entities.Employee;
using ClientDTO = TimesheetManagement.Data.Tasks.Entities.Client;
using ProjectDTO = TimesheetManagement.Data.Tasks.Entities.Project;
using TaskDTO = TimesheetManagement.Data.Tasks.Entities.Task;
using TaskActivityDTO = TimesheetManagement.Data.Tasks.Entities.TaskActivity;

namespace TimesheetManagement.Service.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IManager<Activity, int>, ActivityManager>(new HierarchicalLifetimeManager());
            container.RegisterType<IManager<Employee, int>, EmployeeManager>(new HierarchicalLifetimeManager());
            container.RegisterType<IManager<Client, string>, ClientManager>(new HierarchicalLifetimeManager());
            container.RegisterType<IManager<Project, int>, ProjectManager>(new HierarchicalLifetimeManager());
            container.RegisterType<IManager<Task, int>, TaskManager>(new HierarchicalLifetimeManager());
            container.RegisterType<IManager<TaskActivity, int>, TaskActivityManager>(new HierarchicalLifetimeManager());

            container.RegisterType<IRepository<ActivityDTO, int>, ActivityRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepository<EmployeeDTO, int>, EmployeeRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepository<ClientDTO, string>, ClientRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepository<ProjectDTO, int>, ProjectRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepository<TaskDTO, int>, TaskRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepository<TaskActivityDTO, int>, TaskActivityRepository>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional }
            );

            //Don't support XML
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            //Support Json-patch formatter
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json-patch+json"));

            //Format JSON
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
