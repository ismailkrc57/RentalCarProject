using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
            return new SuccessDataResult<Color>(iColorDal.Get(c => c.Id == id), Messages.ColorListed);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(iColorDal.GetAll(), Messages.ColorListed);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            iColorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            iColorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }

        public IResult Delete(Color color)
        {
            iColorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }
    }
}
