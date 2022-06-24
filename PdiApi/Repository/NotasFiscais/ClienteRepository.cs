using Microsoft.EntityFrameworkCore;
using PdiApi.Models.NotasFiscais;
using PdiApi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PdiApi.Repository.NotasFiscais
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(PdiContext context) : base(context)
        {   }

        public async Task<IList<Cliente>> GetAsync(Expression<Func<Cliente, bool>> busca)
        {
            return await DbSet
                .Where(busca)
                .ToListAsync();
        }

        public async Task<Cliente> GetOneAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IList<Cliente>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Cliente> AddAsync(Cliente cliente)
        {
            await DbSet.AddAsync(cliente);
            await Context.SaveChangesAsync();
            return cliente;
        }

        public async Task DeleteAsync(Cliente cliente)
        {
            DbSet.Remove(cliente);
            await Context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await DbSet.AnyAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            DbSet.Update(cliente);
            await Context.SaveChangesAsync();
        }

    }
}
