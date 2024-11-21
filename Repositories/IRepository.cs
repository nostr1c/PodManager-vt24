using System;
using System.Collections.Generic;

namespace Repositories
{
    public interface IRepository <T> where T : class
    {
        T? GetByGuid(Guid guid);
        void Add(T entity);
        void Update(Guid guid, T entity);
        void Delete(Guid guid);
        List<T> GetAll();
        void SaveChanges();
    }
}