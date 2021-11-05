using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private IColorDal iColorDal;

        public ColorManager(IColorDal iColorDal)
        {
            this.iColorDal = iColorDal;
        }


        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(iColorDal.Get(c => c.Id == id), Message.ColorListed);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(iColorDal.GetAll(), Message.ColorListed);
        }

        public IResult Add(Color color)
        {
            iColorDal.Add(color);
            return new SuccessResult(Message.ColorAdded);
        }

        public IResult Update(Color color)
        {
            iColorDal.Update(color);
            return new SuccessResult(Message.ColorUpdated);
        }

        public IResult Delete(Color color)
        {
            iColorDal.Delete(color);
            return new SuccessResult(Message.ColorDeleted);
        }
    }
}
