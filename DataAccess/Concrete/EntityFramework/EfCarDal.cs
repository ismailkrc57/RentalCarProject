using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public Car Get(Expression<Func<Car, bool>> filterExpression)
        {
            using (EfRentalCarContext context = new EfRentalCarContext())
            {
                return context.Set<Car>().SingleOrDefault(filterExpression);
            }

            ;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filterExpression = null)
        {
            using (EfRentalCarContext context = new EfRentalCarContext())
            {
                return filterExpression == null
                     ? context.Set<Car>().ToList()
                     : context.Set<Car>().Where(filterExpression).ToList();
            }
        }

        public void Add(Car entity)
        {
            using (EfRentalCarContext context = new EfRentalCarContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(Car entity)
        {
            using (EfRentalCarContext context = new EfRentalCarContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (EfRentalCarContext context = new EfRentalCarContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
