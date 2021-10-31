using System;
using System.Linq;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarDetails();
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand = brandManager.GetById(19);
            brand.Name = "Togg" ;
            brandManager.Update(brand);
            foreach (var VARIABLE in brandManager.GetAll())
            {
                Console.WriteLine(VARIABLE.Id + " " + VARIABLE.Name);
            }
        }

        private static void CarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAllCarDetails())
            {
                Console.WriteLine("{0}=={1}=={2}=={3}", car.DailyPrice, car.CarModel, car.BrandName, car.ColorName);
            }
        }
    }
}
