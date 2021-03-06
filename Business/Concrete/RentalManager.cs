﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Entities.Concrete;
using System.Linq;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;
        private IPaymentService _paymentService;

        public RentalManager(IRentalDal rentalDal, IPaymentService paymentService)
        {
            _rentalDal = rentalDal;
            _paymentService = paymentService;
        }

        [ValidationAspect(typeof(RentalValidator))]
        //[SecuredOperation("Rental.Add")]
        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate == null && 
                _rentalDal.GetRentalDetailsById(rental.CarId).Count > 0)
                return new ErrorResult(Messages.NoReturnDate);

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }
        [TransactionScopeAspect]
        public IResult TransactionalOperation(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.CarRentalSuccess);
        }
        [SecuredOperation("Rental.Delete")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == 00)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }
        [PerformanceAspect(5)]
        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(b => b.Id == id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsById(int id)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetailsById(id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>
                (_rentalDal.GetRentalDetails());
        }

        [SecuredOperation("Rental.Update")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
        public IResult CheckRent(int id)
        {
            var result = _rentalDal.GetAll().Where(c => c.CarId == id).LastOrDefault();
            if(result != null  && (result.ReturnDate !=null && result.ReturnDate>=DateTime.Now))
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
