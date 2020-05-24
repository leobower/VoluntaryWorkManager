using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.SwaggerUI;
using Voluntario.Application.Persistence;

namespace Voluntario.API.Rest.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VoluntarioController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] string voluntario, [FromServices]IConfiguration config)
        {
            using (IPersistenceApplication applicationPer
                = new CrossCutting.IoCManager.Voluntario.Application.Persistence.PersistenceApplicationIoCManager(config)
                .GetCurrentIPersistenceApplicationImplementation())
            {
                string _requestId = Guid.NewGuid().ToString();
                applicationPer.RequestId = _requestId;
                applicationPer.VoluntarioSerialized = voluntario;
                try
                {
                    applicationPer.Add();
                    return Created("api/[controller]", applicationPer.Voluntario);
                }
                catch (Exception ex)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
                }

            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] string voluntario, [FromServices]IConfiguration config)
        {
            using (IPersistenceApplication applicationPer
                = new CrossCutting.IoCManager.Voluntario.Application.Persistence.PersistenceApplicationIoCManager(config)
                .GetCurrentIPersistenceApplicationImplementation())
            {
                string _requestId = Guid.NewGuid().ToString();
                applicationPer.RequestId = _requestId;
                applicationPer.VoluntarioSerialized = voluntario;
                try
                {
                    applicationPer.Update();
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
                }

            }
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] string voluntario, [FromServices]IConfiguration config)
        {
            using (IPersistenceApplication applicationPer
                = new CrossCutting.IoCManager.Voluntario.Application.Persistence.PersistenceApplicationIoCManager(config)
                .GetCurrentIPersistenceApplicationImplementation())
            {
                string _requestId = Guid.NewGuid().ToString();
                applicationPer.RequestId = _requestId;
                applicationPer.VoluntarioSerialized = voluntario;
                try
                {
                    applicationPer.Delete();
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
                }

            }
        }

        [HttpGet]
        [Route("/Voluntarios/{cpf}")]
        public IActionResult GetByCPF(string cpf)
        {
            return null;
        }

        [HttpGet]
        [Route("/Voluntarios/{id}")]
        public IActionResult GetById(string id)
        {
            return null;
        }

        [HttpGet]
        [Route("/Voluntarios/{email}")]
        public IActionResult GetByEmail(string email)
        {
            return null;
        }

        [HttpGet]
        [Route("/Voluntarios/{name}")]
        public IActionResult GetByName(string name)
        {
            return null;
        }

        [HttpGet]
        [Route("/Voluntarios/Email/{email}/Pass/{pass}")]
        public IActionResult Login(string email, string pass)
        {
            return null;
        }

    }
}