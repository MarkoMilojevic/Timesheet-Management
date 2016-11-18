using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Marvin.JsonPatch;
using TimesheetManagement.Business.Interfaces;
using TimesheetManagement.Business.Tasks.Entities;

namespace TimesheetManagement.Service.Api.Tasks.Controllers
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

        [Route("taskactivities/{taskId}/{activityId}")]
        public IHttpActionResult Get(int taskId, int activityId)
        {
            try
            {
                TaskActivity taskActivity = taskActivityManager.Find(taskId, activityId);
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

        [Route("tasks/{taskId}/taskactivities")]
        public IHttpActionResult GetByTask(int taskId)
        {
            try
            {
                IEnumerable<TaskActivity> taskActivities = taskActivityManager.Find(ta => ta.Task != null && ta.Task.TaskId == taskId);

                return Ok(taskActivities);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [Route("activities/{activityId}/taskactivities")]
        public IHttpActionResult GetByActivity(int activityId)
        {
            try
            {
                IEnumerable<TaskActivity> taskActivities = taskActivityManager.Find(ta => ta.Activity != null && ta.Activity.ActivityId == activityId);

                return Ok(taskActivities);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [Route("employees/{employeeId}/taskactivities")]
        public IHttpActionResult GetByEmployee(int employeeId)
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

        [Route("taskactivities/{taskId}/{activityId}")]
        public IHttpActionResult Patch(int taskId, int activityId, [FromBody]JsonPatchDocument<TaskActivity> patchDocument)
        {
            try
            {
                if (patchDocument == null)
                {
                    return BadRequest();
                }

                TaskActivity taskActivity = taskActivityManager.Find(taskId, activityId);
                if (taskActivity == null)
                {
                    return NotFound();
                }

                patchDocument.ApplyTo(taskActivity);

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

        [Route("taskactivities/{taskId}/{activityId}")]
        public IHttpActionResult Put(int taskId, int activityId, [FromBody]TaskActivity taskActivity)
        {
            try
            {
                if (taskActivity == null || taskActivity.Task == null || taskActivity.Activity == null)
                {
                    return BadRequest();
                }

                TaskActivity existingTaskActivity = taskActivityManager.Find(taskId, activityId);
                if (existingTaskActivity == null)
                {
                    return Post(taskActivity);
                }

                taskActivity.Task.TaskId = taskId;
                taskActivity.Activity.ActivityId = activityId;
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

        public IHttpActionResult Post([FromBody]TaskActivity taskActivity)
        {
            try
            {
                if (taskActivity == null || taskActivity.Task == null || taskActivity.Activity == null)
                {
                    return BadRequest();
                }

                taskActivity = taskActivityManager.Add(taskActivity);
                if (taskActivity.Task.TaskId == 0 || taskActivity.Activity.ActivityId == 0)
                {
                    return BadRequest();
                }
                
                return Created(Request.RequestUri + "/" + taskActivity.Task.TaskId + "/" + taskActivity.Activity.ActivityId, taskActivity);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [Route("taskactivities/{taskId}/{activityId}")]
        public IHttpActionResult Delete(int taskId, int activityId)
        {
            try
            {
                TaskActivity taskActivity = taskActivityManager.Find(taskId, activityId);
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
    }
}
