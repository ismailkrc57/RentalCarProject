using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;

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
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id), Messages.UserListed);
        }

        public IDataResult<User> GetByEmail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);
            if (result != null)
            {
                return new SuccessDataResult<User>(result);
            }

            return new ErrorDataResult<User>();
        }

        public IDataResult<List<OperationClaim>> GetOperationClaims(User user)
        {
            var result = _userDal.GetAllOperationClaims(user);
            if (result != null)
            {
                return new SuccessDataResult<List<OperationClaim>>(result);
            }

            return new ErrorDataResult<List<OperationClaim>>();
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
        }


        [ValidationAspect(typeof(UserForRegisterValidator))]
        public IResult Add(User user)
        {
            var result = BusinessRule.Run(CheckIfEmailExist(user.Email));
            if (result == null)
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.UserAdded);
            }

            return result;
        }

        [ValidationAspect(typeof(UserForRegisterValidator))]
        public IResult Update(User user)
        {
            if (user == null)
                return new ErrorResult(Messages.EntityNull);
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IResult Delete(User user)
        {
            if (user == null)
                return new ErrorResult(Messages.EntityNull);
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }


        private IResult CheckIfEmailExist(string email)
        {
            var result = _userDal.GetAll(u => u.Email.Equals(email)).Any();
            if (result)
            {
                return new ErrorResult(Messages.EmailExistError);
            }

            return new SuccessResult();
        }
    }
}