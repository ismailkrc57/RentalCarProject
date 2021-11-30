using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Exception;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
namespace Business.Concrete
{
    [ExceptionLogAspect(typeof(FileLogger))]
    [ExceptionLogAspect(typeof(ConsoleLogger))]
    public class RentalManager : IRentalService
    {
        private IRentalDal _iRentalDal;

        public RentalManager(IRentalDal iRentalDal)
        {
            _iRentalDal = iRentalDal;
        }
        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_iRentalDal.Get(r => r.Id == id), Messages.RentalListed);
        }

        public IDataResult<List<Rental>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_iRentalDal.GetAll(r => r.CarId == carId), Messages.RentalListed);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_iRentalDal.GetAll(), Messages.RentalListed);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = BusinessRule.Run(CheckIfReturnDateCorrect(rental));
            if (result == null)
            {
                _iRentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }

            return result;

        }



        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            if (rental == null)
            {
                return new ErrorResult(Messages.EntityNull);
            }

            _iRentalDal.Update(rental);
            return new SuccessResult(Messages.RentAlUpdated);
        }

        public IResult Delete(Rental rental)
        {
            if (rental == null)
            {
                return new ErrorResult(Messages.EntityNull);
            }

            _iRentalDal.Delete(rental);
            return new SuccessResult(Messages.RentAlDeleted);
        }


        private IResult CheckIfReturnDateCorrect(Rental rental)
        {
            var result = _iRentalDal.GetAll(r => r.CarId == rental.CarId);

            foreach (var rntl in result)
            {
                if (rntl.RentDate == DateTime.MinValue || rntl.ReturnDate > rental.RentDate)
                {
                    return new ErrorResult(Messages.Rented);
                }
            }


            return new SuccessResult();
        }
    }
}
