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
            CarManager carManager = new CarManager(new EfCarDal());
           

            carManager.Add(new Car() {Id=1, ColorId = 2, BrandId = 3, DailyPrice = 750, ModelYear = new DateTime(2020, 1, 2), Description = "Deneme descriptions" });
            foreach (var car in carManager.GetAll().ToList())
            {
                Console.WriteLine("Car: {0}", car.Description);
            }

        }
    }
}
