using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PdiApi.Models;
using PdiApi.Models.NotasFiscais;
using PdiApi.Models.Util;
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

        [HttpGet]
        public async Task<Paginated<Receita>> Get([FromQuery] Pagination pagination)
        {
            var Receitas = receitaRepository.GetAllAsync(pagination);
            var Count = receitaRepository.GetCountAsync();
            var Ret = new Paginated<Receita>(
                pagination.Page,
                (await Receitas).Count,
                await Count,
                await Receitas
            );
            return Ret;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            Receita receita = await receitaRepository.GetOneAsync(id);

            if (receita == null)
                return NotFound();
            return Ok(receita);
        }

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

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] Receita receita)
        {
            receita.Id = id;
            await receitaRepository.UpdateAsync(receita);
            return Ok(receita);
        }

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
