using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Exception;
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
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == id), Messages.CustomerListed);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomerListed);
        }

        public IDataResult<List<CustomerDetailsDto>> GetAllCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailsDto>>(_customerDal.GetAllCustomerDetails(),
                Messages.CustomerListed);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {

            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);

        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            if (customer == null)
                return new ErrorResult(Messages.EntityNull);
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }


        public IResult Delete(Customer customer)
        {
            if (customer == null)
                return new ErrorResult(Messages.EntityNull);
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }
    }
}
