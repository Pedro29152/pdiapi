using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PdiApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdiApi.Repository
{
    public class BaseRepository<T> where T : BaseModel
    {
        protected readonly PdiContext Context;
        protected readonly DbSet<T> DbSet;

        public BaseRepository(PdiContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public IDbContextTransaction CreateTransaction()
        {
            return Context.Database.BeginTransaction();
        }
    }
}
