using Core.DataAccess.EntityFramework;
using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal:EfEntityRepsitoryBase<Brand,EfRentalCarContext>, IBrandDal
    {
       
    }
}
