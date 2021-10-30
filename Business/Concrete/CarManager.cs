using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

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
    }
}
