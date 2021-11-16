using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepsitoryBase<Customer, EfRentalCarContext>, ICustomerDal
    {
        public List<CustomerDetailsDto> GetAllCustomerDetails()
        {
            using (EfRentalCarContext context = new EfRentalCarContext())
            {
                var result = from c in context.Customers
                             join u in context.Users on c.UserId equals u.Id
                             select new CustomerDetailsDto()
                             {
                                 FirstName = u.FirstName,
                                 Lastname = u.LastName,
                                 Email = u.Email,
                                 CompanyName = c.CompanyName
                             };
                return result.ToList();
            }
        }
    }
}
