using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<Customer> GetById(int id);
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<CustomerDetailsDto>> GetAllCustomerDetails();
        IResult Add(Customer color);
        IResult Update(Customer color);
        IResult Delete(Customer color);
    }
}
