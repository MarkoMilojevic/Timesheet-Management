using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
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

        public IHttpActionResult Post([FromBody]Activity activity)
        {
            try
            {
                if (activity == null)
                {
                    return BadRequest();
                }

                int activityId = activityManager.Add(activity);
                if (activityId == 0)
                {
                    return BadRequest();
                }

                activity.ActivityId = activityId;
                return Created(Request.RequestUri + "/" + activityId, activity);
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
                    return NotFound();
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
    }
}
