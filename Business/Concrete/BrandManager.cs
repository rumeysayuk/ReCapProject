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
            }
        }

        public void Delete(Brand brand)
        {
            _brandDal.Add(brand);
        }

        public List<Brand> GetAll()
        {
             return  _brandDal.GetAll();
        }
        public List<Brand> GetBrandById(int id)
        {
            return _brandDal.GetAll(b => b.brandId == id);
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }
    }
}
