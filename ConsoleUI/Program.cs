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

            foreach (var car in carManager.GetAllCarDetails())
            {
                Console.WriteLine("{0}=={1}=={2}=={3}", car.Id, car.CarModel, car.BrandName, car.ColorName);
            }

        }
    }
}
