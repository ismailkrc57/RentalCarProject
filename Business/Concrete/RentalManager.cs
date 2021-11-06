using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _iRentalDal;

        public RentalManager(IRentalDal iRentalDal)
        {
            _iRentalDal = iRentalDal;
        }
        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_iRentalDal.Get(r => r.Id == id), Message.RentalListed);
        }

        public IDataResult<List<Rental>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_iRentalDal.GetAll(r => r.CarId == carId), Message.RentalListed);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_iRentalDal.GetAll(), Message.RentalListed);
        }

        public IResult Add(Rental rental)
        {
            var rentals = GetByCarId(rental.CarId);
            foreach (var VARIABLE in rentals.Data)
            {
                if (VARIABLE.ReturnDate == null || VARIABLE.ReturnDate > DateTime.Now)
                    return new ErrorResult(Message.Rented);
            }
            _iRentalDal.Add(rental);
            return new SuccessResult(Message.RentalAdded);
            
        }

        public IResult Update(Rental rental)
        {
            if (rental == null)
            {
                return new ErrorResult(Message.EntityNull);
            }

            _iRentalDal.Update(rental);
            return new SuccessResult(Message.RentAlUpdated);
        }

        public IResult Delete(Rental rental)
        {
            if (rental == null)
            {
                return new ErrorResult(Message.EntityNull);
            }

            _iRentalDal.Delete(rental);
            return new SuccessResult(Message.RentAlDeleted);
        }
    }
}
