using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using TimesheetManagement.Business.Tasks.Managers;
using TimesheetManagement.Data.EntityFramework.Repositories;
using TimesheetManagement.Service.Api.Common.Helpers;

namespace TimesheetManagement.Service.Api.Controllers
{
    [EnableCors("*", "*", "GET")]
	public class ValuesController : ApiController
    {
        private TasksManager tasksManager;

        public ValuesController()
        {
            tasksManager = new TasksManager(new TaskEFRepository());
        }

		// Some test methods
        [VersionedRoute("api/accounts", 1)]
		public IHttpActionResult GetAccounts()
		{
		    return Ok(tasksManager.GetAccounts());
		}

        [VersionedRoute("api/account/{id}/projects", 1)]
        public IHttpActionResult GetProjects(string id)
        {
            return Ok(tasksManager.GetProjects(id));
        }

        [VersionedRoute("api/project/{id}/task", 1)]
        public IHttpActionResult GetProjectTasks(int id)
        {
            return Ok(tasksManager.GetTasks(id));
        }

        // GET api/values/5
        public string Get(int id)
		{
			return "value";
		}

		// POST api/values
		public void Post([FromBody] string value)
		{
		}

		// PUT api/values/5
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
		}
	}
}
