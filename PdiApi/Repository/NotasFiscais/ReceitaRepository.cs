using Microsoft.EntityFrameworkCore;
using PdiApi.Models;
using PdiApi.Models.NotasFiscais;
using PdiApi.Models.Util;
using PdiApi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PdiApi.Repository.NotasFiscais
{
    public class ReceitaRepository : BaseRepository<Receita>, IReceitaRepository
    {
        public ReceitaRepository(PdiContext context) : base(context)
        {   }

        public async Task<IList<Receita>> GetAsync(Expression<Func<Receita, bool>> busca)
        {
            return await DbSet
                .Where(busca)
                .Include(r => r.Cliente)
                .Include(r => r.Contrato)
                .ToListAsync();
        }

        public async Task<Receita> GetOneAsync(Guid id)
        {
            return await DbSet
                .Include(r => r.Cliente)
                .Include(r => r.Contrato)
                .FirstOrDefaultAsync(r => r.Id.Equals(id));
        }

        public async Task<IList<Receita>> GetAllAsync(Pagination pagination)
        {
            return await DbSet
                .Skip(pagination.GetSkip())
                .Take(pagination.PageSize)
                .Include(r => r.Cliente)
                .Include(r => r.Contrato)
                .ToListAsync();
        }

        public async Task<Receita> AddAsync(Receita receita)
        {
            await DbSet.AddAsync(receita);
            await Context.SaveChangesAsync();
            return receita;
        }

        public async Task DeleteAsync(Receita receita)
        {
            DbSet.Remove(receita);
            await Context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await DbSet.AnyAsync(c => c.Id == id);
        }


        public async Task UpdateAsync(Receita receita)
        {
            DbSet.Update(receita);
            await Context.SaveChangesAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await DbSet.CountAsync();
        }
    }
}
