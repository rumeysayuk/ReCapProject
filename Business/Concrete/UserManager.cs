using Business.Abstract;
using Business.Constants;
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
        public IResult Add(User users)
        {
            if (users.Email.Contains("@"))
            {
                _userDal.Add(users);
                return new SuccessResult(Messages.UserAdded);
            }
            return new ErrorResult(Messages.MailInvalid);
        }

        public IResult Delete(User users)
        {
            _userDal.Delete(users);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAllUsers()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<User>>(Messages.UserListed);
        }

        public IDataResult<List<User>> GetByIdUsers(int id)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(p => p.UserId == id), Messages.UserListed);
        }

        public IResult Update(User users)
        {
            _userDal.Update(users);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
