using System.Collections.Generic;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Exception;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
namespace Business.Concrete
{
    [ExceptionLogAspect(typeof(FileLogger))]
    [ExceptionLogAspect(typeof(ConsoleLogger))]
    public class CarManager : ICarService
    {
        private ICarDal iCarDal;

        public CarManager(ICarDal iCarDal)
        {
            this.iCarDal = iCarDal;
        }

        [PerformanceAspect(2)]
        [CacheAspect()]
        [SecuredOperation("getall")]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(iCarDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(iCarDal.Get(c => c.Id == id), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(iCarDal.GetAll(c => c.BrandId == id), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(iCarDal.GetAll(c => c.ColorId == id), Messages.CarListed);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            iCarDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            iCarDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IResult Delete(Car car)
        {
            iCarDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<CarDetailsDto>> GetAllCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(iCarDal.GetAllCarDetails(), Messages.CarsDetailsListed);
        }
    }
}