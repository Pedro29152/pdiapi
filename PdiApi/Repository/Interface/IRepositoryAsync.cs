using PdiApi.Models;
using PdiApi.Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PdiApi.Repository.Interface
{
    public interface IRepositoryAsync<T>
    {
        Task<IList<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetOneAsync(Guid id);
        Task<IList<T>> GetAllAsync(Pagination pagination);
        Task<T> AddAsync(T attr);
        Task UpdateAsync(T attr);
        Task DeleteAsync(T attr);
        Task<bool> ExistsAsync(Guid id);
        Task<int> GetCountAsync();
    }
}
