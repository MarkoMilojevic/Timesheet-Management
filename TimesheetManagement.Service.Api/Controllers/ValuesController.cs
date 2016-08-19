using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using TimesheetManagement.Business.Interfaces.Common;
using TimesheetManagement.Business.Interfaces.Tasks;
using TimesheetManagement.Service.Api.Common.Helpers;
using TimesheetManagement.Business.Tasks;
using TimesheetManagement.Business;
using TimesheetManagement.Business.Tasks.Entities;

namespace TimesheetManagement.Service.Api.Controllers
{
    [EnableCors("*", "*", "GET")]
    //[RoutePrefix("api")]
    public class ValuesController : ApiController
    {
        private ITasksManager tasksManager;
        private ICommonManager commonManager;

        public ValuesController(ITasksManager taskManager, ICommonManager commonManager)
        {
            this.tasksManager = taskManager;
            this.commonManager = commonManager;
        }

		// Some test methods
        [VersionedRoute("api/accounts", 1)]
		public IHttpActionResult GetAccounts()
        {
            ICollection<Account> accounts = tasksManager.GetAccounts();
		    return Ok(accounts);
		}

        [VersionedRoute("api/account/{accountTin}/projects", 1)]
        public IHttpActionResult GetProjects(string accountTin)
        {
            return Ok(tasksManager.GetProjects(accountTin));
        }

        [VersionedRoute("api/employees", 1)] //
        public IHttpActionResult GetEmployees(int eId)
        {
            return Ok(commonManager.GetEmployees());
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
