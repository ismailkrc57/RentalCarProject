using Core.DataAccess.EntityFramework;
using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepsitoryBase<Customer, EfRentalCarContext>, ICustomerDal
    {
    }
}
