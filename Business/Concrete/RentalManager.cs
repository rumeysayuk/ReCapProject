using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
   public class RentalManager:IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rentals)
        {
            var result = CheckReturnDate(rentals.CarId);
            if (!result.Success)
            {
                return new ErrorResult(Messages.CarNotRental);
            }
            _rentalDal.Add(rentals);
            return new SuccessResult(Messages.CarRental);
        }

        public IResult CheckReturnDate(int carId)
        {
            var result = _rentalDal.GetRentalDetails(r => r.CarId == carId && r.ReturnDate == null);
         
            if (result.Count>0)
            {
                return new ErrorResult(Messages.CArNameInvalid);
            }
            return new SuccessResult(Messages.CarRental);
        }
        public IResult UpdateReturnDate(int carId)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId);
            var updateRental = result.LastOrDefault();
            if(updateRental.ReturnDate!= null)
            {
                return new ErrorResult();
            }
            updateRental.ReturnDate = DateTime.Now;
            _rentalDal.Update(updateRental);
            return new SuccessResult(Messages.CarsUpdated);
        }

        public IDataResult<List<Rental>> GetAllRentals()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.CarRental);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails(int carId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.CarId == carId));
        }
    }
}
