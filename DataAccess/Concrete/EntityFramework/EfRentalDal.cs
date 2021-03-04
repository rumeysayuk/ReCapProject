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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (var context=new ReCapProjectContext())
            {
                var result = from rent in context.Rentals
                             join car in context.Cars on rent.CarId equals car.CarId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join cus in context.Customers on rent.CustomerId equals cus.CustomerId
                             join user in context.Users on cus.Id equals user.Id
                             select new RentalDetailDto
                             {
                                 Id = rent.Id,
                                 CarName = car.CarName,
                                 RentDate = rent.RentDate,
                                 ReturnDate = rent.ReturnDate,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName
                             };
                return result.ToList();

            }
        }
    }
}
