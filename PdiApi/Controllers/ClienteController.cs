using Microsoft.AspNetCore.Http;
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
    /* /api/cliente */
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        public IClienteRepository clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IList<Cliente>> Get()
        {
            return await clienteRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            Cliente cliente = await clienteRepository.GetOneAsync(id);

            if (cliente == null)
                return NotFound();
            return Ok(cliente);
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Cliente cliente)
        {
            try
            {
                Cliente ret = await clienteRepository.AddAsync(cliente);

                return Ok(ret);
            }
            catch (DbUpdateException ex)
            {
                return ValidationProblem(ex.Message);
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] Cliente cliente)
        {
            cliente.Id = id;
            await clienteRepository.UpdateAsync(cliente);
            return Ok(cliente);
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            Cliente cliente = await clienteRepository.GetOneAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            await clienteRepository.DeleteAsync(cliente);
            return Ok(cliente);

        }
    }
}
