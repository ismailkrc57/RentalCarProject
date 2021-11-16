using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepsitoryBase<User, EfRentalCarContext>, IUserDal
    {
        public List<OperationClaim> GetAllOperationClaims(User user)
        {
            using (var context = new EfRentalCarContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims on operationClaim.Id equals
                                 userOperationClaim.OperationClaimId
                             where user.Id == userOperationClaim.UserId
                             select new OperationClaim()
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name
                             };
                return result.ToList();
            }
        }
    }
}
