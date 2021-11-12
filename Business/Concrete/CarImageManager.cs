using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Mime;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }


        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Message.ImagesListed);
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
                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(ci => ci.CarId == carId), Message.ImagesListed);
            }

            CarImage defaultCarIamge = new CarImage()
            {
                CarId = carId,
                Date = DateTime.Now,
                ImagePath = "Images/default.png"
            };
            return new SuccessDataResult<List<CarImage>>(new List<CarImage>() { defaultCarIamge }, Message.DefaultImagesListed);
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
                return new SuccessResult(Message.ImageAdded);
            }

            return imageResult;



        }


        public IResult Delete(CarImage carImage)
        {
            var result = FileHelper.Delete(carImage.ImagePath);
            if (result.Success)
            {
                _carImageDal.Delete(carImage);
                return new SuccessResult(Message.ImageDeleted);
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
                return new ErrorResult(Message.NumberOfImageError);
            }

            return new SuccessResult();
        }

        private IResult CheckCarHasAnyImage(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId).Any();
            if (!result)
            {
                return new ErrorResult(Message.ThereIsNoImagesError);
            }

            return new SuccessResult();
        }
    }
}
