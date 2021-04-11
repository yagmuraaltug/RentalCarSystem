using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using Entities.Concrete;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapContext>, IUserDal
    {
        public List<string> GetClaims(Expression<Func<User, bool>> filter = null)
        {
            using (var context = new ReCapContext())
            {
                var result = from user in filter is null ? context.Users : context.Users.Where(filter)
                             join userOperationClaim in context.UserOperationClaims on user.Id equals userOperationClaim.UserId
                             join operationClaim in context.OperationClaims on userOperationClaim.OperationClaimId equals operationClaim.Id
                             where userOperationClaim.UserId == user.Id
                             select new List<string> {  operationClaim.Name };
                return (List<string>)result;

            }

        }

        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ReCapContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }


    }

   
       
    
}
