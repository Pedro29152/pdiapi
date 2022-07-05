using PdiApi.Models;
using PdiApi.Models.Util;
using System;
using System.Linq;

namespace PdiApi.Repository.Interface
{
    public interface IRepository<T>
    {
        IQueryable<T> Get(Pagination pagination);
        T GetOne(Guid? id);
        void Add(T attr);
        void Update(T attr);
        void Delete(T attr);
        bool Exists(int id);
    }
}
