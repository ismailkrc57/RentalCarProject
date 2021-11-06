using Core.DataAccess.EntityFramework;
using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepsitoryBase<User, EfRentalCarContext>, IUserDal
    {
    }
}
