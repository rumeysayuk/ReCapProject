using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public IResult Add(Car car)
        { 
            
            if(car.Description.Length > 1 && car.DailyPrice>0 )
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
                
            }
            else
            {
               if(car.Description.Length<2) Console.WriteLine("Tanım 2 karakterden az olamaz.");
               if (car.DailyPrice < 0) Console.WriteLine("0 TL den büyük bir değer giriniz.");
                return new ErrorResult(Messages.CArNameInvalid);
            }
           
            
        }
        public IResult Delete(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarsDeleted);
    
           
        }
        public IResult Update(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarsUpdated);
             
        }
        public IDataResult< List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 5)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
           return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }

        public IDataResult< List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult< List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(c => c.ColorId == id));
        }
        public IDataResult< List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>( _carDal.GetCarDetails());
        }

        public IDataResult< List<Car>> GetCarsByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(c=>c.DailyPrice >= min && c.DailyPrice <= max));
        }
    }
}
