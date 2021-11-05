using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    interface ICustomerService
    {
        IDataResult<Customer> GetById(int id);
        IDataResult<List<Customer>> GetAll();
        IResult Add(Customer color);
        IResult Update(Customer color);
        IResult Delete(Customer color);
    }
}
