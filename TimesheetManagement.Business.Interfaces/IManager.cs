using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TimesheetManagement.Business.Interfaces
{
    public interface IManager<T, in TKey> where T : class
    {
        T Add(T obj);

        bool Remove(T obj);

        bool Update(T obj);

        T Find(params TKey[] keys);

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        IEnumerable<T> FindAll();
    }
}
