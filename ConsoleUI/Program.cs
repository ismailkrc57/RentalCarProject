using System;
using System.Linq;
using Business.Concrete;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll().ToList())
            {
                Console.WriteLine("Car: {0}", car.Description);
            }
        }
    }
}
