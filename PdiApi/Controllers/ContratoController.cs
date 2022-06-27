using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PdiApi.Models;
using PdiApi.Models.Contratos;
using PdiApi.Repository;
using PdiApi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PdiApi.Controllers
{
    /* /api/contrato */
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        public IContratoRepository contratoRepository;
        //public ILogger _logger;

        public ContratoController(IContratoRepository contratoRepository/*, ILogger _logger */)
        {
            //this._logger = _logger;
            this.contratoRepository = contratoRepository;
        }

        // GET: api/<ContratoController>
        [HttpGet]
        public async Task<IList<Contrato>> Get()
        {
            return await contratoRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            Contrato contrato = await contratoRepository.GetOneAsync(id);
            
            if (contrato == null) 
                return NotFound();
            return Ok(contrato);
        }

        // POST api/<ContratoController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Contrato contrato)
        {
            try
            {
                Contrato ret = await contratoRepository.AddAsync(contrato);

                return Ok(ret);
            }
            catch (DbUpdateException ex)
            {
                return ValidationProblem(ex.Message);
            }
        }

        // PUT api/<ContratoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] Contrato contrato)
        {
            contrato.Id = id;
            await contratoRepository.UpdateAsync(contrato);
            return Ok(contrato);
        }

        // DELETE api/<ContratoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            Contrato contrato = await contratoRepository.GetOneAsync(id);
            if (contrato == null)
            {
                return NotFound();
            }
            await contratoRepository.DeleteAsync(contrato);
            return Ok(contrato);
        }
    }
}
