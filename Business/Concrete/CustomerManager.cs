using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
  public  class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;        
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customers)
        {
            _customerDal.Add(customers);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customers)
        {
            _customerDal.Delete(customers);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAllCustomers()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomerAdded);
        }

        public IDataResult <Customer> GetByCompanyName(string companyName)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<Customer>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Customer>(_customerDal.Get(p => p.CompanyName.Contains(companyName)),Messages.CustomerAdded) ;
        }

        public IResult Update(Customer customers)
        {
            _customerDal.Update(customers);
            return new SuccessResult(Messages.UserUpdated);
        }

        IDataResult<Customer> ICustomerService.GetByCompanyName(string companyName)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(p => p.CompanyName.Contains(companyName)), Messages.CustomerAdded);
        }
    }
}
