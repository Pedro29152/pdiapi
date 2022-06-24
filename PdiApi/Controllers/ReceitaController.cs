using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PdiApi.Models.NotasFiscais;
using PdiApi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdiApi.Controllers
{
    /* /api/receita */
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitaController : Controller
    {
        public IReceitaRepository receitaRepository;

        public ReceitaController(IReceitaRepository receitaRepository)
        {
            this.receitaRepository = receitaRepository;
        }

        // GET: api/<ReceitaController>
        [HttpGet]
        public async Task<IList<Receita>> Get()
        {
            return await receitaRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            Receita receita = await receitaRepository.GetOneAsync(id);

            if (receita == null)
                return NotFound();
            return Ok(receita);
        }

        // POST api/<ReceitaController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Receita receita)
        {
            try
            {
                Receita ret = await receitaRepository.AddAsync(receita);

                return Ok(ret);
            }
            catch (DbUpdateException ex)
            {
                return ValidationProblem(ex.InnerException.Message);
            }
        }

        // PUT api/<ReceitaController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] Receita receita)
        {
            receita.Id = id;
            await receitaRepository.UpdateAsync(receita);
            return Ok(receita);
        }

        // DELETE api/<ReceitaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            Receita receita = await receitaRepository.GetOneAsync(id);
            if (receita == null)
            {
                return NotFound();
            }
            await receitaRepository.DeleteAsync(receita);
            return Ok(receita);
        }
    }
}
