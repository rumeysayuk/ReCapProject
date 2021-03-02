using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
   public  class InMemoryCarDal:ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                 new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=1,Description="Kaliteli araba" },
                 new Car{CarId=2,BrandId=1,ColorId=2,DailyPrice=2,Description="Güzel araba" },
                 new Car{CarId=2,BrandId=1,ColorId=3,DailyPrice=3,Description="Mor araba" },
                 new Car{CarId=2,BrandId=1,ColorId=4,DailyPrice=4,Description="Pahali araba" },
                 new Car{CarId=2,BrandId=1,ColorId=5,DailyPrice=5,Description="Kalitesiz araba" },

            };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }
        public void Delete(Car car )
        {
            Car carToDelete = null;
            carToDelete = _car.SingleOrDefault(c => c.CarId == car.CarId);
        }
        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
        public List<Car> GetAll()
        {
            return _car.ToList(); ;
        }
        public List<Car> GetById(int carId)
        {
            return _car.Where(c => c.CarId == carId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
           return _car.ToList();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
