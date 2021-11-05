using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        public IDataResult<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Add(User color)
        {
            throw new NotImplementedException();
        }

        public IResult Update(User color)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(User color)
        {
            throw new NotImplementedException();
        }
    }
}
