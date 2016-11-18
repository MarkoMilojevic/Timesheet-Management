using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Marvin.JsonPatch;
using Newtonsoft.Json;
using TimesheetManagement.Business.Entities;
using TimesheetManagement.Business.Interfaces;

namespace TimesheetManagement.Service.Api.Controllers
{
    public class EmployeesController : ApiController
	{
        private readonly IManager<Employee, int> employeeManager;

	    public EmployeesController(IManager<Employee, int> employeeManager)
	    {
	        this.employeeManager = employeeManager;
	    }
        
        public IHttpActionResult Get()
        {
            try
            {
                IEnumerable<Employee> employees = employeeManager.FindAll();

                return Ok(employees);
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
                Employee employee = employeeManager.Find(id);
                if (employee == null)
                {
                    return NotFound();
                }

                return Ok(employee);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Patch(int id, [FromBody]JsonPatchDocument<Employee> patchDocument)
        {
            try
            {
                if (patchDocument == null)
                {
                    return BadRequest();
                }

                Employee employee = employeeManager.Find(id);
                if (employee == null)
                {
                    return NotFound();
                }

                patchDocument.ApplyTo(employee);

                bool isUpdated = employeeManager.Update(employee);
                if (isUpdated)
                {
                    return Ok(employee);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Put(int id, [FromBody]Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest();
                }

                Employee existingEmployee = employeeManager.Find(id);
                if (existingEmployee == null)
                {
                    return Post(employee);
                }

                employee.EmployeeId = id;
                bool isUpdated = employeeManager.Update(employee);
                if (isUpdated)
                {
                    return Ok(employee);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Post([FromBody]Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest();
                }
                
                employee = employeeManager.Add(employee);
                if (employee.EmployeeId == 0)
                {
                    return BadRequest();
                }
                
                return Created(Request.RequestUri + "/" + employee.EmployeeId, employee);
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
                Employee employee = employeeManager.Find(id);
                if (employee == null)
                {
                    return NotFound();
                }

                bool isDeleted = employeeManager.Remove(employee);
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
