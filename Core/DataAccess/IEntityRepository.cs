using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filterExpression);
        List<T> GetAll(Expression<Func<T, bool>> filterExpression = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
