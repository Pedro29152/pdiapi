using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PdiApi.Models;
using PdiApi.Models.Contratos;
using PdiApi.Models.Util;
using PdiApi.Repository;
using PdiApi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdiApi.Controllers
{
    /* /api/contrato */
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        public IContratoRepository contratoRepository;

        public ContratoController(IContratoRepository contratoRepository)
        {
            this.contratoRepository = contratoRepository;
        }

        [HttpGet]
        public async Task<Paginated<Contrato>> Get([FromQuery] Pagination pagination)
        {
            var Contratos = contratoRepository.GetAllAsync(pagination);
            var Count = contratoRepository.GetCountAsync();
            var Ret = new Paginated<Contrato>(
                pagination.Page, 
                (await Contratos).Count, 
                await Count, 
                await Contratos
            );
            return Ret;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            Contrato contrato = await contratoRepository.GetOneAsync(id);
            
            if (contrato == null) 
                return NotFound();
            return Ok(contrato);
        }

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

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] Contrato contrato)
        {
            contrato.Id = id;
            await contratoRepository.UpdateAsync(contrato);
            return Ok(contrato);
        }

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
