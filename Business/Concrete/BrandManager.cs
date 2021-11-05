using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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


        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(iBrandDal.Get(b => b.Id == id), Message.BrandListed);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(iBrandDal.GetAll(), Message.BrandListed);
        }

        public IResult Add(Brand brand)
        {
            iBrandDal.Add(brand);
            return new SuccessResult(Message.BrandAdded);
        }

        public IResult Update(Brand brand)
        {
            iBrandDal.Update(brand);
            return new SuccessResult(Message.BrandUpdated);
        }

        public IResult Delete(Brand brand)
        {
            iBrandDal.Delete(brand);
            return new SuccessResult(Message.BrandDeleted);
        }
    }
}
