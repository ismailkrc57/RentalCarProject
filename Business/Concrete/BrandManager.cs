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
    public class BrandManager : IBrandService
    {
        private IBrandDal iBrandDal;

        public BrandManager(IBrandDal iBrandDal)
        {
            this.iBrandDal = iBrandDal;
        }

        public Brand GetById(int id)
        {
            return iBrandDal.Get(b => b.Id == id);
        }

        public List<Brand> GetAll()
        {
            return iBrandDal.GetAll();
        }

        public void Add(Brand brand)
        {
            iBrandDal.Add(brand);
        }

        public void Update(Brand brand)
        {
            iBrandDal.Update(brand);
        }

        public void Delete(Brand brand)
        {
            iBrandDal.Delete(brand);
        }
    }
}
