using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User users);
        IResult Delete(User users);
        IResult Update(User users);
        IDataResult< List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByMail(string email);
        IDataResult<List<User>> GetAllUsers();
        IDataResult<List<User>> GetByIdUsers(int id);
    }   
}
