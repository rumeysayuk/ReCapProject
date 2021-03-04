using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User users)
        {
              _userDal.Add(users);
              return new SuccessResult(Messages.UserAdded);   
        }

        public IResult Delete(User users)
        {
            _userDal.Delete(users);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAllUsers()
        {
            if (DateTime.Now.Hour == 3)
            {
                return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<User>>(Messages.UserListed);
        }

        public IDataResult<List<User>> GetByIdUsers(int id)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(p => p.Id == id), Messages.UserListed);
        }

        public IDataResult< User> GetByMail(string email)
        {
            return new SuccessDataResult<User> (_userDal.Get(u => u.Email == email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user), Messages.ClaimsListed);
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User users)
        {
            _userDal.Update(users);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
