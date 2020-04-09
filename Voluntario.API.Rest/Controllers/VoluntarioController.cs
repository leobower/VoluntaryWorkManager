using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.API.Rest.Controllers
{
    public class VoluntarioController : Controller
    {
        // POST api/values
        [HttpPost]
        public void Post([FromBody] IVoluntario value)
        {
            //TODO
        }
    }
}