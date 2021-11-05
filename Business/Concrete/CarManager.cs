using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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


        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(iCarDal.GetAll(),Message.CarListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(iCarDal.GetAll(c => c.BrandId == id), Message.CarListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(iCarDal.GetAll(c => c.ColorId == id), Message.CarListed);
        }

        public IResult Add(Car car)
        {
            iCarDal.Add(car);
            return new SuccessResult(Message.CarAdded);
        }

        public IResult Update(Car car)
        {
            iCarDal.Update(car);
            return new SuccessResult(Message.CarUpdated);
        }

        public IResult Delete(Car car)
        {
            iCarDal.Delete(car);
            return new SuccessResult(Message.CarDeleted);
        }

        public IDataResult<List<CarDetailsDto>> GetAllCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(iCarDal.GetAllCarDetails(), Message.CarsDetailsListed);
        }
    }
}
