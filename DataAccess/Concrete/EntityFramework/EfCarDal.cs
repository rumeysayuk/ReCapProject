using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.brandId
                             join co in context.Colors on c.ColorId equals co.ColorId
                             select new CarDetailDto { ColorId = c.ColorId ,BrandId=b.brandId,ColorName=co.ColorName,Description=c
                             .Description,BrandName=b.BrandName,DailyPrice=c.DailyPrice,Id=c.Id};

               return result.ToList();           
            }
        }
    }     
    
}
