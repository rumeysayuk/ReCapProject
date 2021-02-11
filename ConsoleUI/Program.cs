 using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new EfCarDal());
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.BrandId);
            //}

            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Car cars1 = new Car() { ColorId = 1, BrandId = 2, DailyPrice = 300, Description = "şimşek mac", Id = 1 };
            Car cars2 = new Car() { BrandId = 3, ColorId = 4, DailyPrice = 400, Description = "hızlı ve öfkeli", Id = 2 };
            Brand brand1 = new Brand() { brandId = 3, BrandName = "yukomata" };
            Color color = new Color() { ColorId = 3, ColorName = "Yeşil" };
           
            List<Car> Cars= new List<Car> { cars1, cars2 };
            Console.WriteLine("Crud test");
            // carManager.Add(cars1);
            //carManager.Delete(cars1.Id(3);
            Console.WriteLine("Tüm araçlar");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id+"Numaralı"+car.ColorId + "Color nolu :"+ car.BrandId+"Brand nolu :"+car.DailyPrice+" TL Günlük ücretli"+car.Description +"Aracı.");
            }


            Console.WriteLine("Aynı markalı araçlar");
            foreach (var car1 in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car1.Id + car1.Description);
            }

            Console.WriteLine("Aynı renkli araçlar");
            foreach (var car2 in carManager.GetCarsByColorId(4))
            {
                Console.WriteLine(car2.ColorId + car2.Description + car2.DailyPrice);
            }
            Console.WriteLine("Araç detayları ");
            foreach (var details in carManager.GetCarDetails())
            {
                Console.WriteLine(details.Id+details.BrandId+details.BrandName+details.ColorId+details.ColorName+details.DailyPrice+details.Description);
            }

            Console.WriteLine("Marka eklendi");
            brandManager.Add(new Brand{ BrandName= " Corolla" });
            Console.WriteLine("Renk eklendi");
            colorManager.Add(new Color {ColorName = " Purple " });

            Console.WriteLine("Markalar listelendi");
            foreach (var brand in brandManager.GetBrandById(3))
            {
                Console.WriteLine("  Brand Id : " + brand.brandId + "  Brand name : " + brand.BrandName);
            }
            Console.WriteLine("Renkler listelendi");
            foreach (var color1 in colorManager.GetColorById(3))
            {
                Console.WriteLine("  Color Id : " + color1.ColorId + "  Color name : " + color1.ColorName);
            }

        }
    }
}
