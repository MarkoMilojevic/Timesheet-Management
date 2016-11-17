using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Marvin.JsonPatch;
using TimesheetManagement.Business.Interfaces;
using TimesheetManagement.Business.Tasks.Entities;

namespace TimesheetManagement.Service.Api.Tasks.Controllers
{
    public class ClientsController : ApiController
    {
        private readonly IManager<Client, string> clientManager;

        public ClientsController(IManager<Client, string> clientManager)
        {
            this.clientManager = clientManager;
        }

        public IHttpActionResult Get()
        {
            try
            {
                IEnumerable<Client> clients = clientManager.FindAll();

                return Ok(clients);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Get(string id)
        {
            try
            {
                Client client = clientManager.Find(id);
                if (client == null)
                {
                    return NotFound();
                }

                return Ok(client);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Patch(string id, [FromBody]JsonPatchDocument<Client> patchDocument)
        {
            try
            {
                if (patchDocument == null)
                {
                    return BadRequest();
                }

                Client client = clientManager.Find(id);
                if (client == null)
                {
                    return NotFound();
                }

                patchDocument.ApplyTo(client);

                bool isUpdated = clientManager.Update(client);
                if (isUpdated)
                {
                    return Ok(client);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Put(string id, [FromBody]Client client)
        {
            try
            {
                if (client == null)
                {
                    return BadRequest();
                }

                Client existingClient = clientManager.Find(id);
                if (existingClient == null)
                {
                    return Post(client);
                }

                bool isUpdated = clientManager.Update(client);
                if (isUpdated)
                {
                    return Ok(client);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Post([FromBody]Client client)
        {
            try
            {
                if (client == null)
                {
                    return BadRequest();
                }

                client = clientManager.Add(client);
                if (client.TaxpayerIdentificationNumber == null)
                {
                    return BadRequest();
                }
                
                return Created(Request.RequestUri + "/" + client.TaxpayerIdentificationNumber, client);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Delete(string id)
        {
            try
            {
                Client client = clientManager.Find(id);
                if (client == null)
                {
                    return NotFound();
                }

                bool isDeleted = clientManager.Remove(client);
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
