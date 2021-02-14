using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IRentalService
    {
        IResult Add(Rental rentals);

        IResult CheckReturnDate(int carId);
        IResult UpdateReturnDate(int carId);
        IDataResult<List<RentalDetailDto>> GetRentalDetails(int carId);
        IDataResult<List<Rental>> GetAllRentals();

    }
}
