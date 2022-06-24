using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PdiApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class PdiApiController : ControllerBase
    {
        [HttpGet]
        public ObjectResult Get()
        {
            return Ok(new { nome = "PDI API 1.0" });
        }
    }
}
