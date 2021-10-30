using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Entities.Abstract;

namespace DataAccess.Abstract
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
