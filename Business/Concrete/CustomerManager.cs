using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        public IDataResult<Customer> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Customer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Add(Customer color)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Customer color)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Customer color)
        {
            throw new NotImplementedException();
        }
    }
}
