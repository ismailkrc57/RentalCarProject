using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<Rental> GetById(int id);
        IDataResult<List<Rental>> GetByCarId(int carId);
        IDataResult<List<Rental>> GetAll();
        IResult Add(Rental color);
        IResult Update(Rental color);
        IResult Delete(Rental color);
    }
}
