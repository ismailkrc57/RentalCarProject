using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepsitoryBase<Car, EfRentalCarContext>, ICarDal
    {
        public List<CarDetailsDto> GetAllCarDetails()
        {
            using (EfRentalCarContext context = new EfRentalCarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join cl in context.Colors on c.ColorId equals cl.Id
                             select new CarDetailsDto()
                             {
                                 DailyPrice = c.DailyPrice,
                                 CarModel = c.CarModel,
                                 BrandName = b.Name,
                                 ColorName = cl.Name
                             };
                return result.ToList();
            }
        }
    }
}
