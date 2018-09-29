using System.Collections.Generic;

namespace Aiub.Ums.Core.Service.Interfaces
{
    public interface IService<T> where T : class
    {
        bool Add(T entity);
        bool Edit(T entity);
        bool Remove<TKey>(TKey id);
        IEnumerable<T> GetAll();
        T GetById<TKey>(TKey id);
    }
}