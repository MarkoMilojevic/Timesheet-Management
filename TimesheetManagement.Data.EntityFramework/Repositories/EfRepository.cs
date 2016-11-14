using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TimesheetManagement.Data.EntityFramework.Entities;
using TimesheetManagement.Data.Interfaces;

namespace TimesheetManagement.Data.EntityFramework.Repositories
{
    public abstract class EfRepository<T, TKey> : IRepository<T, TKey> where T : class
    {
        protected readonly TimesheetContext context;

        protected EfRepository()
        {
            context = new TimesheetContext();
        }

        public abstract TKey Add(T obj);

        public abstract bool Remove(T obj);

        public abstract T Find(params TKey[] keys);

        public abstract IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        public abstract IEnumerable<T> FindAll();
    }
}