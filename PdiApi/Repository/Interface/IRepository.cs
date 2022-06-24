using System;
using System.Linq;

namespace PdiApi.Repository.Interface
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        T GetOne(Guid? id);
        void Add(T attr);
        void Update(T attr);
        void Delete(T attr);
        bool Exists(int id);
    }
}
