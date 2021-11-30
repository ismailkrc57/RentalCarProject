using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Exception;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;


namespace Business.Concrete
{
    [ExceptionLogAspect(typeof(FileLogger))]
    [ExceptionLogAspect(typeof(ConsoleLogger))]
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }


        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.ImagesListed);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRule.Run(CheckCarHasAnyImage(carId));
            if (result==null)
            {
                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(ci => ci.CarId == carId), Messages.ImagesListed);
            }

            CarImage defaultCarIamge = new CarImage()
            {
                CarId = carId,
                Date = DateTime.Now,
                ImagePath = "Images/default.png"
            };
            return new SuccessDataResult<List<CarImage>>(new List<CarImage>() { defaultCarIamge }, Messages.DefaultImagesListed);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile image, CarImage carImage)
        {
            var result = BusinessRule.Run(CheckCountOfImage(carImage));
            if (result != null)
                return result;


            var imageResult = FileHelper.Upload(image);

            if (imageResult.Success)
            {
                carImage.ImagePath = imageResult.Message;
                carImage.Date = DateTime.Now;
                _carImageDal.Add(carImage);
                return new SuccessResult(Messages.ImageAdded);
            }

            return imageResult;

        }


        public IResult Delete(CarImage carImage)
        {
            var result = FileHelper.Delete(carImage.ImagePath);
            if (result.Success)
            {
                _carImageDal.Delete(carImage);
                return new SuccessResult(Messages.ImageDeleted);
            }

            return result;
        }

        public IResult Update(CarImage carImage)
        {
            throw new NotImplementedException();
        }

        private IResult CheckCountOfImage(CarImage carImage)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carImage.CarId).Count();
            if (result >= 5)
            {
                return new ErrorResult(Messages.NumberOfImageError);
            }

            return new SuccessResult();
        }

        private IResult CheckCarHasAnyImage(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.ThereIsNoImagesError);
            }

            return new SuccessResult();
        }
    }
}
