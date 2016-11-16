using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using TimesheetManagement.Business.Interfaces;
using TimesheetManagement.Business.Tasks.Entities;

namespace TimesheetManagement.Service.Api.Tasks.Controllers
{
    [RoutePrefix("api")]
    public class TasksController : ApiController
    {
        private readonly IManager<Task, int> taskManager;

        public TasksController(IManager<Task, int> taskManager)
        {
            this.taskManager = taskManager;
        }

        public IHttpActionResult Get()
        {
            try
            {
                IEnumerable<Task> tasks = taskManager.FindAll();

                return Ok(tasks);
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
                Task task = taskManager.Find(id);
                if (task == null)
                {
                    return NotFound();
                }

                return Ok(task);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [Route("projects/{projectId}/tasks")]
        public IHttpActionResult GetByProject(int projectId)
        {
            try
            {
                IEnumerable<Task> tasks = taskManager.Find(t => t.Project != null && t.Project.ProjectId == projectId);
                
                return Ok(tasks);
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
                Task task = taskManager.Find(id);
                if (task == null)
                {
                    return NotFound();
                }

                bool isDeleted = taskManager.Remove(task);
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

        public IHttpActionResult Post([FromBody]Task task)
        {
            try
            {
                if (task == null)
                {
                    return BadRequest();
                }

                task = taskManager.Add(task);
                if (task.TaskId == 0)
                {
                    return BadRequest();
                }
                
                return Created(Request.RequestUri + "/" + task.TaskId, task);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Put(int id, [FromBody]Task task)
        {
            try
            {
                if (task == null)
                {
                    return BadRequest();
                }

                Task existingTask = taskManager.Find(id);
                if (existingTask == null)
                {
                    return NotFound();
                }

                bool isUpdated = taskManager.Update(task);
                if (isUpdated)
                {
                    return Ok(task);
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
