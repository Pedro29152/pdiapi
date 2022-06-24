using Microsoft.EntityFrameworkCore;
using PdiApi.Models;
using PdiApi.Models.Contratos;
using PdiApi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PdiApi.Repository.Contratos
{
    public class ContratoRepository : BaseRepository<Contrato>, IContratoRepository
    {
        public ContratoRepository(PdiContext context) : base(context)
        { }

        public async Task<IList<Contrato>> GetAsync(Expression<Func<Contrato, bool>> busca)
        {
            return await DbSet
                .Where(busca)
                .Include(c => c.Cliente)
                .Include(c => c.Receitas)
                .ToListAsync();
        }

        public async Task<Contrato> GetOneAsync(Guid id)
        {
            return await DbSet
                .Include(c => c.Cliente)
                .Include(c => c.Receitas)
                .FirstOrDefaultAsync(c => c.Id.Equals(id));
        }
        public async Task<IList<Contrato>> GetAllAsync()
        {
            return await DbSet
                .Include(c => c.Cliente)
                .Include(c => c.Receitas)
                .ToListAsync();
        }

        public async Task<Contrato> AddAsync(Contrato contrato)
        {
            await DbSet.AddAsync(contrato);
            await Context.SaveChangesAsync();
            return contrato;
        }

        public async Task DeleteAsync(Contrato contrato)
        {
            DbSet.Remove(contrato);
            await Context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await DbSet.AnyAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Contrato contrato)
        {
            DbSet.Update(contrato);
            await Context.SaveChangesAsync();
        }

    }
}
