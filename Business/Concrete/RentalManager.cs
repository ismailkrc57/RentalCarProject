using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public IDataResult<List<Rental>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Add(Rental color)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Rental color)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Rental color)
        {
            throw new NotImplementedException();
        }
    }
}
