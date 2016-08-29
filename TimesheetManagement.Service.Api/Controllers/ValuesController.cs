using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using TimesheetManagement.Business.Interfaces;
using TimesheetManagement.Business.Tasks.Entities;
using TimesheetManagement.Business.Tasks.Interfaces;
using TimesheetManagement.Service.Api.Common.Helpers;

namespace TimesheetManagement.Service.Api.Controllers
{
    [EnableCors("*", "*", "GET")]
    //[RoutePrefix("api")]
    public class ValuesController : ApiController
    {
        private readonly ICommonManager commonManager;
        private readonly ITasksManager tasksManager;

        public ValuesController(ITasksManager taskManager, ICommonManager commonManager)
        {
            tasksManager = taskManager;
            this.commonManager = commonManager;
        }

        [VersionedRoute("api/employees", 1)] //
        public IHttpActionResult GetEmployees(int eId)
        {
            return Ok(commonManager.GetEmployees());
        }

        // Some test methods
        [VersionedRoute("api/accounts", 1)]
        public IHttpActionResult GetAccounts()
        {
            ICollection<Account> accounts = tasksManager.GetAccounts();
            return Ok(accounts);
        }

        [VersionedRoute("api/accounts/{accountId}/projects", 1)]
        public IHttpActionResult GetProjects(string accountId)
        {
            return Ok(tasksManager.GetProjects(accountId));
        }

        [VersionedRoute("api/projects/{projectId}/tasks", 1)]
        public IHttpActionResult GetTasks(int projectId)
        {
            return Ok(tasksManager.GetTasks(projectId));
        }

        [VersionedRoute("api/taskactivities/{employeeId}", 1)] //
        public IHttpActionResult GetTaskActivites(int employeeId)
        {
            return Ok(tasksManager.GetTaskActivities(employeeId));
        }

        [HttpPost]
        [VersionedRoute("api/taskactivities", 1)] //
        public IHttpActionResult CreateTaskActivity(TaskActivity taskActivity)
        {
            tasksManager.CreateTaskActivity(taskActivity);
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
