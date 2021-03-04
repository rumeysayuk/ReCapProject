using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Business.Constants;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using Core.Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserManager userManager = new UserManager(new EfUserDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            customerManager.Add(new Customer { Id = 1, CompanyName = "Tesla" });
            customerManager.Add(new Customer { Id = 1, CompanyName = "Amazon" });
            customerManager.Add(new Customer { Id = 1, CompanyName = "Trendyol" });


            //userManager.Add(new User { Email = "asd@gmail.com", FirstName = "Rümeysa", LastName = "Yük", Password = 123456, });
            //userManager.Add(new User { Email = "yusuf@gmail.com", FirstName = "Ahmet", LastName = "Tas", Password = 7895 });
            //userManager.Add(new User { Email = "mahmut@gmail.com", FirstName = "Nuriye", LastName = "Ulsak", Password = 896321 });
            //userManager.Add(new User { Email = "yalın@gmail.com", FirstName = "Kemal", LastName = "atcı", Password = 7852 });

            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var cust in result.Data)
                {
                    Console.WriteLine("{0} -- {1} -- {2}", cust.BrandName, cust.ColorName, cust.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            var result2 = customerManager.GetAllCustomers();
            foreach (var re in result2.Data)
            {
                Console.WriteLine(re.CompanyName);

            }

            var result4 = rentalManager.CheckReturnDate(23 / 11 / 2021);
                foreach (var item in result4.Message)
                {
                    Console.WriteLine("Araç kıralanabilir");
                }

            //var result5 = userManager.GetAllUsers();
            //foreach (var item in result5.Data)
            //{
            //    Console.WriteLine(item.Email+item.FirstName+item.LastName+item.Password);
            //}



                //Test(carManager, brandManager, colorManager);
                //Test2(brandManager, colorManager);

            
        }
        private static void Test2(BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("Ürünlerin Markasını Listele");
            var result = brandManager.GetAll();
            foreach (var brand in result.Data)
            {
                Console.WriteLine(brand.BrandId + "/" + brand.BrandName);
            }

            //brandManager.Add(new Brand { BrandId = 6, BrandName="Toyota" });

            Console.WriteLine("Ürünlerin Rengini Listele");
            var result2 = colorManager.GetAll();
            foreach (var color in result2.Data)
            {
                Console.WriteLine(color.ColorId + "/" + color.ColorName);
            }

            colorManager.Add(new Color { ColorId = 6, ColorName = "Green" });
        }

        private static void Test(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            brandManager.Add(new Brand { BrandName = "Togg" });
            colorManager.Add(new Color { ColorName = "kahverengi" });
            Console.WriteLine("Tüm ürünleri Lİstele");
            carManager.Add(new Car { BrandId = 30, ColorId = 31, CarName = " Şimsek mac ", DailyPrice = 500, Description = " Hızlı", ModelYear = 2019 });
            carManager.Add(new Car { BrandId = 31, ColorId = 32, CarName = " Electric Power ", DailyPrice = 1000, Description = " Elektikli", ModelYear = 2021 });
            carManager.Add(new Car { BrandId = 32, ColorId = 34, CarName = " Dizel Power ", DailyPrice = 2000, Description = " Dizelli", ModelYear = 2001 });
            carManager.Add(new Car { BrandId = 33, ColorId = 35, CarName = "Motor Power ", DailyPrice = 300, Description = " Motorlu", ModelYear = 1999 });
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Car ID :" + car.CarId + "Brand Id : " + car.BrandId + " Color ıd : " + car.ColorId);
                }
            }

            Console.WriteLine("Renk kodu 34 olan Araçlar Listeleniyor");
            var result2 = carManager.GetCarsByColorId(32);
            foreach (var car in result2.Data)
            {
                Console.WriteLine("Araç no :" + car.CarId + " " + car.ModelYear + " " + car.Description + "Günlük Kiralama Bedeli: " + car.DailyPrice + "TL" + car.CarName);
            }
            Console.WriteLine("---Fiyatı Min. 100 Maks. 500 Olan Ürünleri Listele---");
            var result3 = carManager.GetCarsByDailyPrice(100, 500);
            foreach (var car in result3.Data)
            {
                Console.WriteLine(car.CarId + " " + car.ModelYear + " " + car.Description + "Günlük Kiralama Bedeli: " + car.DailyPrice + "TL");
            }

            Console.WriteLine("Araba Id, Marka, Renk Listele (Join operasyonu ile)");
            var result4 = carManager.GetCarDetails();
            foreach (var car in result4.Data)
            {
                Console.WriteLine(car.CarId + "/" + car.BrandName + "/" + car.ColorName);
            }
        }
    }
}
