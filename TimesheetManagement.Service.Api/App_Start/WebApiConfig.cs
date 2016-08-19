using System.Net.Http.Headers;
using System.Web.Http;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TimesheetManagement.Business.Interfaces;
using TimesheetManagement.Business.Tasks.Interfaces;
using TimesheetManagement.Business.Managers;
using TimesheetManagement.Business.Tasks.Managers;
using TimesheetManagement.Data.EntityFramework.Repositories;
using TimesheetManagement.Data.Interfaces.Common;
using TimesheetManagement.Data.Interfaces.Tasks;
using TimesheetManagement.Service.Api.Helpers;

namespace TimesheetManagement.Service.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<ITasksManager, TasksManager>(new HierarchicalLifetimeManager());
            container.RegisterType<ICommonManager, CommonManager>(new HierarchicalLifetimeManager());

            container.RegisterType<ITaskRepository, TaskEFRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IActivityRepository, ActivityEFRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IEmployeeRepository, EmployeeEFRepository>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new {id = RouteParameter.Optional}
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
