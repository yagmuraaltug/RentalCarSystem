using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        public void Add(User user)
        {
            _userDal.Add(user);
        }



        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(p => p.UserEmail == email);
        }

        public IDataResult<User> GetUserDetailByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserEmail == email));
        }

      

        public IDataResult<User> GetUserById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(user => user.Id == userId));
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<Findex> GetUserFindeks(Findex findex)
        {
            throw new NotImplementedException();
        }
    }
    }


