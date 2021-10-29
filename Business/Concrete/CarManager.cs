using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal icarCarDal;

        public CarManager(ICarDal icarCarDal)
        {
            this.icarCarDal = icarCarDal;
        }

        public List<Car> GetAll()
        {
            return icarCarDal.GetAll();
        }
    }
}
