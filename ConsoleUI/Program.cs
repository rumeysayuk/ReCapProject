using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Business.Constants;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            brandManager.Add(new Brand { BrandName = "Togg" });
            colorManager.Add(new Color { ColorName = "kahverengi" });
            Console.WriteLine("Tüm ürünleri Lİstele");
            carManager.Add(new Car {  BrandId = 30, ColorId = 31, CarName = " Şimsek mac ", DailyPrice = 500, Description = " Hızlı", ModelYear = 2019 });
            carManager.Add(new Car {  BrandId = 31, ColorId = 32, CarName = " Electric Power ", DailyPrice = 1000, Description = " Elektikli", ModelYear = 2021 });
            carManager.Add(new Car { BrandId = 32, ColorId = 34, CarName = " Dizel Power ", DailyPrice = 2000, Description = " Dizelli", ModelYear = 2001 });
            carManager.Add(new Car { BrandId = 33, ColorId = 35, CarName = "Motor Power ", DailyPrice = 300, Description = " Motorlu", ModelYear = 1999 });
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Car ID :" + car.CarId + "Brand Id : " + car.BrandId + " Color ıd : " + car.ColorId );
                }
            }

            Console.WriteLine("Renk kodu 34 olan Araçlar Listeleniyor");
             var  result2 = carManager.GetCarsByColorId(32);
            foreach (var car in result2.Data)
            {
                Console.WriteLine("Araç no :"+car.CarId + " " + car.ModelYear + " " + car.Description + "Günlük Kiralama Bedeli: " + car.DailyPrice + "TL"+car.CarName);
            }
            Console.WriteLine("---Fiyatı Min. 100 Maks. 500 Olan Ürünleri Listele---");
            var result3 = carManager.GetCarsByDailyPrice(100, 500);
            foreach (var car in result3.Data) 
            {
                Console.WriteLine(car.CarId + " " + car.ModelYear + " " + car.Description + "Günlük Kiralama Bedeli: " + car.DailyPrice + "TL");
            }

            Console.WriteLine("Araba Id, Marka, Renk Listele (Join operasyonu ile)");
            var result4 = carManager.GetCarDetails();
            foreach (var car in result4.Data )
            {
                Console.WriteLine(car.CarId + "/" + car.BrandName + "/" + car.ColorName);
            }

            //Console.WriteLine("Ürünlerin Markasını Listele");

            //foreach (var brand in brandManager.GetAll())
            //{
            //    Console.WriteLine(brand.BrandId + "/" + brand.BrandName);
            //}

            ////brandManager.Add(new Brand { BrandId = 6, BrandName="Toyota" });

            //Console.WriteLine("Ürünlerin Rengini Listele");

            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.WriteLine(color.ColorId + "/" + color.ColorName);
            //}

            //colorManager.Add(new Color { ColorId = 6, ColorName = "Green" });


        }
    }
}
