using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using TimesheetManagement.Business.Interfaces;
using TimesheetManagement.Business.Tasks.Entities;
using TimesheetManagement.Service.Api.Models;

namespace TimesheetManagement.Service.Api.Controllers
{
    [RoutePrefix("api")]
    public class TaskActivitiesController : ApiController
    {
        private readonly IManager<TaskActivity, int> taskActivityManager;

        public TaskActivitiesController(IManager<TaskActivity, int> taskActivityManager)
        {
            this.taskActivityManager = taskActivityManager;
        }

        public IHttpActionResult Get()
        {
            try
            {
                IEnumerable<TaskActivity> taskActivities = taskActivityManager.FindAll();

                return Ok(taskActivities);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
        
        public IHttpActionResult Get([FromUri] TaskActivityId location)
        {
            try
            {
                TaskActivity taskActivity = taskActivityManager.Find(location.TaskId, location.ActivityId);
                if (taskActivity == null)
                {
                    return NotFound();
                }

                return Ok(taskActivity);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [Route("taskactivities/{employeeId}")]
        public IHttpActionResult GetTaskActivites(int employeeId)
        {
            try
            {
                IEnumerable<TaskActivity> taskActivities = taskActivityManager.Find(ta => ta.Activity != null && ta.Activity.Employee != null && ta.Activity.Employee.EmployeeId == employeeId);
                
                return Ok(taskActivities);
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
                TaskActivity taskActivity = taskActivityManager.Find(id);
                if (taskActivity == null)
                {
                    return NotFound();
                }

                bool isDeleted = taskActivityManager.Remove(taskActivity);
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

        public IHttpActionResult Post([FromBody]TaskActivity taskActivity)
        {
            try
            {
                if (taskActivity == null)
                {
                    return BadRequest();
                }

                int taskActivityId = taskActivityManager.Add(taskActivity);
                if (taskActivityId == 0)
                {
                    return BadRequest();
                }
                
                return Created(Request.RequestUri + "/" + taskActivityId, taskActivity);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Put(int id, [FromBody]TaskActivity taskActivity)
        {
            try
            {
                if (taskActivity == null)
                {
                    return BadRequest();
                }

                TaskActivity existingTaskActivity = taskActivityManager.Find(id);
                if (existingTaskActivity == null)
                {
                    return NotFound();
                }

                bool isUpdated = taskActivityManager.Update(taskActivity);
                if (isUpdated)
                {
                    return Ok(taskActivity);
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
