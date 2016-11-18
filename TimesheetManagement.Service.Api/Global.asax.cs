using System.Web.Http;
using System.Web.Mvc;

namespace TimesheetManagement.Service.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            ControllerBuilder.Current.DefaultNamespaces.Add("TimesheetManagement.Service.Api.Tasks.Controllers");
        }
    }
}
