using System.Collections.Generic;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Exception;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    [ExceptionLogAspect(typeof(FileLogger))]
    [ExceptionLogAspect(typeof(ConsoleLogger))]
    public class BrandManager : IBrandService
    {
        private IBrandDal iBrandDal;

        public BrandManager(IBrandDal iBrandDal)
        {
            this.iBrandDal = iBrandDal;
        }


        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(iBrandDal.Get(b => b.Id == id), Messages.BrandListed);
        }

        //[SecuredOperation("getall")]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(iBrandDal.GetAll(), Messages.BrandListed);
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            iBrandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            iBrandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }

        public IResult Delete(Brand brand)
        {
            iBrandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }
    }
}