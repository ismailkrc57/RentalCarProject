using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
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

        public IResult Add(User user)
        {
            if (user == null)
                return new ErrorResult(Message.EntityNull);
            _userDal.Add(user);
            return new SuccessResult(Message.UserAdded);
        }

        public IResult Update(User user)
        {
            if (user == null)
                return new ErrorResult(Message.EntityNull);
            _userDal.Update(user);
            return new SuccessResult(Message.UserAdded);
        }

        public IResult Delete(User user)
        {
            if (user == null)
                return new ErrorResult(Message.EntityNull);
            _userDal.Delete(user);
            return new SuccessResult(Message.UserDeleted);
        }
    }
}
