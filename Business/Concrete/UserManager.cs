using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id), Message.UserListed);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Message.UserListed);
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            var result = BusinessRule.Run(CheckIfEmailExist(user.Email));
            if (result.Success)
            {
                _userDal.Add(user);
                return new SuccessResult(Message.UserAdded);
            }

            return result;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            if (user == null)
                return new ErrorResult(Message.EntityNull);
            _userDal.Update(user);
            return new SuccessResult(Message.UserUpdated);
        }

        public IResult Delete(User user)
        {
            if (user == null)
                return new ErrorResult(Message.EntityNull);
            _userDal.Delete(user);
            return new SuccessResult(Message.UserDeleted);
        }


        private IResult CheckIfEmailExist(string email)
        {
            var result = _userDal.GetAll(u => u.Email.Equals(email)).Any();
            if (result)
            {
                return new ErrorResult(Message.EmailExistError);
            }

            return new SuccessResult();
        }
    }
}
