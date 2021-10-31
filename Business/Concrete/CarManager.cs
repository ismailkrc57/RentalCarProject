using System.Collections.Generic;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal iCarDal;

        public CarManager(ICarDal iCarDal)
        {
            this.iCarDal = iCarDal;
        }

        public List<Car> GetAll()
        {
            return iCarDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return iCarDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return iCarDal.GetAll(c => c.ColorId == id);
        }

        public void Add(Car car)
        {
            if (car.Description.Length > 2 && car.DailyPrice > 0)
            {
                iCarDal.Add(car);
            }
        }

        public void Update(Car car)
        {
            iCarDal.Update(car);
        }

        public void Delete(Car car)
        {
            iCarDal.Delete(car);
        }

        public List<CarDetailsDto> GetAllCarDetails()
        {
            return iCarDal.GetAllCarDetails();
        }
    }
}
