using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Swashbuckle.AspNetCore.SwaggerUI;
using Voluntario.Application.Persistence;
using Voluntario.Application.Query;

namespace Voluntario.API.Rest.Controllers
{
    [Route("api/v1/voluntario")]
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
                string requestId = Guid.NewGuid().ToString();
                applicationPer.RequestId = requestId;
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
                string requestId = Guid.NewGuid().ToString();
                applicationPer.RequestId = requestId;   
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
                string requestId = Guid.NewGuid().ToString();
                applicationPer.RequestId = requestId;
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
        [Route("cpf/{cpf}")]
        public IActionResult GetByCPF(string cpf, [FromServices]IConfiguration config)
        {
            if(long.TryParse(cpf,out long cpfParsed))
            {
                try
                {
                    using (IQueryApplication queryApplication
                            = new CrossCutting.IoCManager.Voluntario.Application.Query.QueryApplicationIoCManager(config).GetCurrentIQueryApplicationImplementation())
                    {
                        string requestId = Guid.NewGuid().ToString();
                        queryApplication.RequestId = requestId;
                        queryApplication.Cpf = cpfParsed;
                        var obj = queryApplication.GetByCpf();
                        if (obj != null)
                            return StatusCode(200, JToken.FromObject(obj));
                        else
                            return StatusCode(404);
                    }
                }
                catch (Exception ex)
                {
                    //TODO: log de exception
                    return StatusCode(500);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("id/{id}")]
        public IActionResult GetById(string id, [FromServices]IConfiguration config)
        {
            if (!string.IsNullOrEmpty(id) && Guid.TryParse(id, out Guid idParsed))
            {
                try
                {
                    using (IQueryApplication queryApplication
                            = new CrossCutting.IoCManager.Voluntario.Application.Query.QueryApplicationIoCManager(config).GetCurrentIQueryApplicationImplementation())
                    {
                        string requestId = Guid.NewGuid().ToString();
                        queryApplication.RequestId = requestId;
                        queryApplication.VoluntarioId = id;
                        var obj = queryApplication.GetById();
                        if (obj != null)
                            return StatusCode(200, JToken.FromObject(obj));
                        else
                            return StatusCode(404);
                    }
                }
                catch (Exception ex)
                {
                    //TODO: log de exception
                    return StatusCode(500);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("email/{email}")]
        public IActionResult GetByEmail(string email, [FromServices]IConfiguration config)
        {
            if (!string.IsNullOrEmpty(email))
            {
                try
                {
                    using (IQueryApplication queryApplication
                            = new CrossCutting.IoCManager.Voluntario.Application.Query.QueryApplicationIoCManager(config).GetCurrentIQueryApplicationImplementation())
                    {
                        string requestId = Guid.NewGuid().ToString();
                        queryApplication.RequestId = requestId;
                        queryApplication.Email = email;
                        var obj = queryApplication.GetByEmail();
                        if (obj != null)
                            return StatusCode(200, JToken.FromObject(obj));
                        else
                            return StatusCode(404);
                    }
                }
                catch (Exception ex)
                {
                    //TODO: log de exception
                    return StatusCode(500);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("name/{name}")]
        public IActionResult GetByName(string name, [FromServices]IConfiguration config)
        {
            if (!string.IsNullOrEmpty(name))
            {
                try
                {
                    using (IQueryApplication queryApplication
                            = new CrossCutting.IoCManager.Voluntario.Application.Query.QueryApplicationIoCManager(config).GetCurrentIQueryApplicationImplementation())
                    {
                        string requestId = Guid.NewGuid().ToString();
                        queryApplication.RequestId = requestId;
                        queryApplication.VoluntarioName = name;
                        var obj = queryApplication.GetByName();
                        if (obj != null)
                            return StatusCode(200, JArray.FromObject(obj));
                        else
                            return StatusCode(404);
                    }
                }
                catch (Exception ex)
                {
                    //TODO: log de exception
                    return StatusCode(500);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        //[HttpGet]
        //[Route("Email/{email}/Pass/{pass}")]
        //public IActionResult Login(string email, string pass, [FromServices]IConfiguration config)
        //{
        //    if (!string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass))
        //    {
        //        try
        //        {
        //            using (IQueryApplication queryApplication
        //                    = new CrossCutting.IoCManager.Voluntario.Application.Query.QueryApplicationIoCManager(config).GetCurrentIQueryApplicationImplementation())
        //            {
        //                string requestId = Guid.NewGuid().ToString();
        //                queryApplication.RequestId = requestId;
        //                queryApplication.Email = name;
        //                var obj = queryApplication.GetByName();
        //                return StatusCode(200, JArray.FromObject(obj));
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            //TODO: log de exception
        //            return StatusCode(500);
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}

    }
}