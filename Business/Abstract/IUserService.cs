using Core.Entities.Concrete;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        IResult Update(User user);
        User GetByMail(string email);
        IDataResult<User> GetUserById(int userId);
        IDataResult<Findex> GetUserFindeks(Findex findex);
        IDataResult<User> GetUserDetailByMail(string email);



    }
}
