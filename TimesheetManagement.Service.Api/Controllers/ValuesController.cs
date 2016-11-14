using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using TimesheetManagement.Business.Entities;
using TimesheetManagement.Business.Interfaces;
using TimesheetManagement.Business.Tasks.Entities;
using TimesheetManagement.Service.Api.Common.Helpers;

namespace TimesheetManagement.Service.Api.Controllers
{
    [EnableCors("*", "*", "GET")]
    //[RoutePrefix("api")]
    public class ValuesController : ApiController
    {
        private readonly IManager<Employee, int> employeeManager;
        private readonly IManager<Activity, int> activityManager;
        private readonly IManager<Client, string> clientManager;
        private readonly IManager<Project, int> projectManager;
        private readonly IManager<Task, int> taskManager;
        private readonly IManager<TaskActivity, int> taskActivityManager;

        public ValuesController(IManager<Employee, int> employeeManager, IManager<Activity, int> activityManager, IManager<Client, string> clientManager, IManager<Project, int> projectManager, IManager<Task, int> taskManager, IManager<TaskActivity, int> taskActivityManager)
        {
            this.employeeManager = employeeManager;
            this.activityManager = activityManager;
            this.clientManager = clientManager;
            this.projectManager = projectManager;
            this.taskManager = taskManager;
            this.taskActivityManager = taskActivityManager;
        }


        [VersionedRoute("api/employees", 1)] //
        public IHttpActionResult GetEmployees(int eId)
        {
            return Ok(employeeManager.Find(eId));
        }

        // Some test methods
        [VersionedRoute("api/accounts", 1)]
        public IHttpActionResult GetAccounts()
        {
            IEnumerable<Client> accounts = clientManager.FindAll();
            return Ok(accounts);
        }

        [VersionedRoute("api/accounts/{accountId}/projects", 1)]
        public IHttpActionResult GetProjects(string accountId)
        {
            return Ok(projectManager.Find(p => p.Client != null && p.Client.TaxpayerIdentificationNumber == accountId));
        }

        [VersionedRoute("api/projects/{projectId}/tasks", 1)]
        public IHttpActionResult GetTasks(int projectId)
        {
            return Ok(taskManager.Find(t => t.Project != null && t.Project.ProjectId == projectId));
        }

        [VersionedRoute("api/taskactivities/{employeeId}", 1)] //
        public IHttpActionResult GetTaskActivites(int employeeId)
        {
            return Ok(taskActivityManager.Find(ta => ta.Activity != null && ta.Activity.Employee != null && ta.Activity.Employee.EmployeeId == employeeId));
        }

        [HttpPost]
        [VersionedRoute("api/taskactivities", 1)] //
        public IHttpActionResult CreateTaskActivity(TaskActivity taskActivity)
        {
            taskActivityManager.Add(taskActivity);
            return Ok();
        }

        // GET values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST values
        public void Post([FromBody] string value)
        {
        }

        // PUT values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE values/5
        public void Delete(int id)
        {
        }
    }
}
