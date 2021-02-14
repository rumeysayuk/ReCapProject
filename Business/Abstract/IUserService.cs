using Core.Utilities.Results;
using Entities.Concrete;
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
        IDataResult<List<User>> GetAllUsers();
        IDataResult<List<User>> GetByIdUsers(int id);
    }
}
