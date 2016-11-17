using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Marvin.JsonPatch;
using TimesheetManagement.Business.Entities;
using TimesheetManagement.Business.Interfaces;

namespace TimesheetManagement.Service.Api.Controllers
{
    [RoutePrefix("api")]
    public class ActivitiesController : ApiController
    {
        private readonly IManager<Activity, int> activityManager;

        public ActivitiesController(IManager<Activity, int> activityManager)
        {
            this.activityManager = activityManager;
        }

        public IHttpActionResult Get()
        {
            try
            {
                IEnumerable<Activity> activities = activityManager.FindAll();

                return Ok(activities);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                Activity activity = activityManager.Find(id);
                if (activity == null)
                {
                    return NotFound();
                }

                return Ok(activity);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [Route("employees/{employeeId}/activities")]
        public IHttpActionResult GetByEmployee(int employeeId)
        {
            try
            {
                IEnumerable<Activity> activities = activityManager.Find(a => a.Employee != null && a.Employee.EmployeeId == employeeId);

                return Ok(activities);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Patch(int id, [FromBody]JsonPatchDocument<Activity> patchDocument)
        {
            try
            {
                if (patchDocument == null)
                {
                    return BadRequest();
                }

                Activity activity = activityManager.Find(id);
                if (activity == null)
                {
                    return NotFound();
                }

                patchDocument.ApplyTo(activity);

                bool isUpdated = activityManager.Update(activity);
                if (isUpdated)
                {
                    return Ok(activity);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Put(int id, [FromBody]Activity activity)
        {
            try
            {
                if (activity == null)
                {
                    return BadRequest();
                }

                Activity existingActivity = activityManager.Find(id);
                if (existingActivity == null)
                {
                    return Post(activity);
                }

                bool isUpdated = activityManager.Update(activity);
                if (isUpdated)
                {
                    return Ok(activity);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Post([FromBody]Activity activity)
        {
            try
            {
                if (activity == null)
                {
                    return BadRequest();
                }

                activity = activityManager.Add(activity);
                if (activity.ActivityId == 0)
                {
                    return BadRequest();
                }
                
                return Created(Request.RequestUri + "/" + activity.ActivityId, activity);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                Activity activity = activityManager.Find(id);
                if (activity == null)
                {
                    return NotFound();
                }

                bool isDeleted = activityManager.Remove(activity);
                if (isDeleted)
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
