using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    interface IRentalService
    {
        IDataResult<Rental> GetById(int id);
        IDataResult<List<Rental>> GetAll();
        IResult Add(Rental color);
        IResult Update(Rental color);
        IResult Delete(Rental color);
    }
}
