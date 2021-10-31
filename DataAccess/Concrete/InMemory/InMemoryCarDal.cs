using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _Cars;

        public InMemoryCarDal()
        {
            _Cars = new List<Car>()
            {
                new Car(){Id = 1,BrandId = 1,ColorId = 1,DailyPrice = 2500,ModelYear = new DateTime(2000,1,1),Description = "çok iyi 2000 model araba"},
                new Car(){Id = 2,BrandId = 1,ColorId = 2,DailyPrice = 3500,ModelYear = new DateTime(1999,1,1),Description = "çok iyi 99 model araba"},
                new Car(){Id = 3,BrandId = 2,ColorId = 3,DailyPrice = 4000,ModelYear = new DateTime(2005,1,1),Description = "çok iyi 2005 model araba"},
                new Car(){Id = 4,BrandId = 2,ColorId = 4,DailyPrice = 3800,ModelYear = new DateTime(2010,1,1),Description = "çok iyi 2010 model araba"},
            };
        }

        public Car GetById(int id)
        {
            return _Cars.SingleOrDefault(c => c.Id == id);
        }

        public List<Car> GetAll()
        {
            return _Cars;
        }

        public Car Get(Expression<Func<Car, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filterExpression = null)
        {
            throw new NotImplementedException();
        }

        public void Add(Car car)
        {
            _Cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = GetById(car.Id);
            _Cars.Remove(carToDelete);
        }

        public List<CarDetailsDto> GetAllCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = GetById(car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
