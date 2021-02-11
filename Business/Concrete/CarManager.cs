using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
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
        public void Add(Car car)
        { 
            
            if(car.Description.Length > 1 && car.DailyPrice>0 )
            {
                _carDal.Add(car);          
            }
            else
            {
               if(car.Description.Length<2) Console.WriteLine("Tanım 2 karakterden az olamaz.");
                if (car.DailyPrice < 0) Console.WriteLine("0 dan büyük bir değer giriniz.");
            }
           
            
        }
        public void Delete(Car car)
        {
            _carDal.Add(car);        
        }
        public void Update(Car car)
        {
             _carDal.Add(car);  
        }
        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }
        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
