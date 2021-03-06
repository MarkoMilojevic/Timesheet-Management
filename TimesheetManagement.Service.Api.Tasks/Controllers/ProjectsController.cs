﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Marvin.JsonPatch;
using TimesheetManagement.Business.Interfaces;
using TimesheetManagement.Business.Tasks.Entities;

namespace TimesheetManagement.Service.Api.Tasks.Controllers
{
    [RoutePrefix("api")]
    public class ProjectsController : ApiController
    {
        private readonly IManager<Project, int> projectManager;

        public ProjectsController(IManager<Project, int> projectManager)
        {
            this.projectManager = projectManager;
        }

        public IHttpActionResult Get()
        {
            try
            {
                IEnumerable<Project> projects = projectManager.FindAll();

                return Ok(projects);
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
                Project project = projectManager.Find(id);
                if (project == null)
                {
                    return NotFound();
                }

                return Ok(project);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [Route("clients/{clientId}/projects")]
        public IHttpActionResult GetByClient(string clientId)
        {
            try
            {
                IEnumerable<Project> projects = projectManager.Find(p => p.Client != null && p.Client.TaxpayerIdentificationNumber == clientId);

                return Ok(projects);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Patch(int id, [FromBody]JsonPatchDocument<Project> patchDocument)
        {
            try
            {
                if (patchDocument == null)
                {
                    return BadRequest();
                }

                Project project = projectManager.Find(id);
                if (project == null)
                {
                    return NotFound();
                }

                patchDocument.ApplyTo(project);

                bool isUpdated = projectManager.Update(project);
                if (isUpdated)
                {
                    return Ok(project);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Put(int id, [FromBody]Project project)
        {
            try
            {
                if (project == null)
                {
                    return BadRequest();
                }

                Project existingProject = projectManager.Find(id);
                if (existingProject == null)
                {
                    return Post(project);
                }

                project.ProjectId = id;
                bool isUpdated = projectManager.Update(project);
                if (isUpdated)
                {
                    return Ok(project);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Post([FromBody]Project project)
        {
            try
            {
                if (project == null)
                {
                    return BadRequest();
                }

                project = projectManager.Add(project);
                if (project.ProjectId == 0)
                {
                    return BadRequest();
                }
                
                return Created(Request.RequestUri + "/" + project.ProjectId, project);
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
                Project project = projectManager.Find(id);
                if (project == null)
                {
                    return NotFound();
                }

                bool isDeleted = projectManager.Remove(project);
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
