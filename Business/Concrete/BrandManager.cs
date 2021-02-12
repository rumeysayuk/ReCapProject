using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public void Add(Brand brand)
        {
            if (brand.BrandName.Length > 2)
            {
                _brandDal.Add(brand);
                Console.WriteLine("Marka eklendi.");
            }
            else
            {
                Console.WriteLine("Marka ismi 2 karakterden fazla olmalıdır.");
            }
        }

        public void Delete(Brand brand)
        {
            _brandDal.Add(brand);
            Console.WriteLine("Marka silindi.");
        }

        public List<Brand> GetAll()
        {
             return  _brandDal.GetAll();
        }
        public List<Brand> GetCarsByBrandId(int brandId)
        {
            return _brandDal.GetAll(b => b.BrandId == brandId);
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
            Console.WriteLine("Marka güncellendi.");
        }
    }
}
