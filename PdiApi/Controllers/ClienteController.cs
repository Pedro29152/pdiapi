using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public async Task<Paginated<Cliente>> Get([FromQuery] Pagination pagination)
        {
            var Clientes = clienteRepository.GetAllAsync(pagination);
            var Count = clienteRepository.GetCountAsync();
            var Ret = new Paginated<Cliente>(
                pagination.Page,
                (await Clientes).Count,
                await Count,
                await Clientes
            );
            return Ret;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            Cliente cliente = await clienteRepository.GetOneAsync(id);

            if (cliente == null)
                return NotFound();
            return Ok(cliente);
        }

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

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] Cliente cliente)
        {
            cliente.Id = id;
            await clienteRepository.UpdateAsync(cliente);
            return Ok(cliente);
        }

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
