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
    [Route("api/[controller]")]
    [ApiController]
    public class VoluntarioController : ControllerBase
    {
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] string voluntario, [FromServices]IConfiguration config)
        {
            //TODO
            string connStr = config.GetSection("connStr").Value;
            string dataBase = config.GetSection("dataBase").Value;
            string collection = config.GetSection("collection").Value;
            string requestId = Guid.NewGuid().ToString();

            IPersistenceApplication applicationPer 
                = new CrossCutting.IoCManager.Voluntario.Application.Persistence.PersistenceApplicationIoCManager().GetCurrentIPersistenceApplicationImplementation(connStr, dataBase, collection);

            applicationPer.RequestId = requestId;
            applicationPer.VoluntarioSerialized = voluntario;
            try
            {
                applicationPer.Add();
                return Ok(voluntario);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,ex.Message);
            }


        }
    }
}