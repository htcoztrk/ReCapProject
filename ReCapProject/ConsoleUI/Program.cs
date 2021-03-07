using System;
using Business.Concrete;
using Core.Entities.Concrete;
using Core.Utilities.Helpers;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            CarImageManager carImageManager = new CarImageManager(new EfCarImageDal());

           // var result = carImageManager.Add(new CarImage{  CarId=1, CarImageDate=new DateTime(), ImagePath="default.jpeg" });
            //Console.WriteLine(result.Message);

            // TestToAdd(carManager,brandManager, colorManager);
            //TestToUpdate(carManager, brandManager, colorManager);
            //TestToDelete(carManager, brandManager, colorManager);

            //List of tables
            //ListOfCar(carManager);
            //ListOfColor(colorManager);
            //ListOfBrand(brandManager);

            //GetCarDetail(carManager);


            //TestToAddUser(userManager);
            //TestToAddCustomer(customerManager);
            //TestToUpdateCustomer(customerManager);
            // TestToDeleteRental(rentalManager);

            //kiralama testinde eğer araba returndate'i null ise araba kiralanamıyor.
            ///TestToAddRental(rentalManager);


            Console.ReadKey();
        }
        
        static void TestToAddRental(RentalManager rentalManager)
        {
            Console.WriteLine("*********Test To Add Rental***********");
            var result=rentalManager.Add(new Rental { CarId=1, CustomerId=1, RentDate=new DateTime(2020,02,02), ReturnDate=new DateTime(2021,02,02) });
            Console.WriteLine(result.Message);
            var result2=rentalManager.Add(new Rental { CarId = 2, CustomerId = 2, RentDate = new DateTime(2020, 02, 02), ReturnDate =null });
            Console.WriteLine(result2.Message);
            var result3 = rentalManager.Add(new Rental { CarId=3,CustomerId=2, RentDate=new DateTime(2021,02,15), ReturnDate=null });
            Console.WriteLine(result3.Message);
        }
        static void TestToDeleteRental(RentalManager rentalManager)
        {
            var result = rentalManager.Delete(new Rental { CarId = 2, CustomerId = 1, RentalId = 1002, RentDate = new DateTime(2021, 01, 21), ReturnDate = new DateTime(2021, 02, 05) });
            Console.WriteLine(result.Message);
        }
        static void TestToAddUser(UserManager userManager)
        {
            Console.WriteLine("************Testing to Add User***********");
            //userManager.Add(new User { FirstName = "H", LastName = "O", Email = "ho@gmail.com", Password = "h1o1" });
            //userManager.Add(new User { FirstName = "M", LastName = "O", Email = "mo@gmail.com", Password = "m1o1" });
        }
        static void TestToAddCustomer(CustomerManager customerManager)
        {
            Console.WriteLine("************Testing to Add Customer***********");

            var result = customerManager.Add(new Customer { UserId = 2, CompanyName = "Company 2" });
            Console.WriteLine(result.Message);


        }
        static void GetCarDetail(CarManager carManager)
        {
            Console.WriteLine("*********Details Of Car***********");
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("CAR NAME: " + car.CarName + " " + "BRAND NAME: " + car.BrandName + " " + "COLOR NAME: " + car.ColorName + " " + "DAILY PRICE: " + car.DailyPrice);

                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
           
        }
        static void ListOfCar(CarManager carManager)
        {
            Console.WriteLine("*********List Of Car***********");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarId +" "+ car.CarName+" " + car.DailyPrice+" "+car.Descriptions+" "+car.ModelYear);

            }
            
        }
        static void ListOfColor(ColorManager colorManager)
        {
            Console.WriteLine("*********List Of Color***********");
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorId + " " + color.ColorName);

            }
        }
        static void ListOfBrand(BrandManager brandManager)
        {
            Console.WriteLine("*********List Of Brand***********");
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId + " " +brand.BrandName);

            }
        }
        static void TestToAdd(CarManager carManager , BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("************Testing to Add operation***********");
            brandManager.Add(new Brand { BrandName = "Clio" });
            colorManager.Add(new Color { ColorName = "Red" });
            carManager.Add(new Car { BrandId = 3, ColorId = 3, CarName="Toyota-2020", DailyPrice = 200, Descriptions = "Otomatic Dizel", ModelYear = 2010 });
         
        } 
        static void TestToUpdateCustomer(CustomerManager customerManager)
        {
            Console.WriteLine("************Testing to Update Customer***********");

            var result = customerManager.Update(new Customer { CompanyName = "Company 3" , CustomerId=3, UserId=2});
            Console.WriteLine(result.Message);


        }
        static void TestToUpdate(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("************Testing to Update operation***********");
            brandManager.Update(new Brand { BrandId = 4, BrandName = "Mercedes" });
            colorManager.Update(new Color { ColorId = 4, ColorName = "Mavi" });
            carManager.Update(new Car { BrandId = 4, CarName="Mercedes Benz", CarId = 5, ColorId = 4, DailyPrice = 200, Descriptions = "Otomatic Hybrid", ModelYear = 2010 });
        }
        static void TestToDelete(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("************Testing to Delete operation***********");
            brandManager.Delete(new Brand { BrandId = 8, BrandName = "Clio" });
            colorManager.Delete(new Color { ColorId = 8, ColorName = "Red" });
            carManager.Delete(new Car { BrandId = 5, CarId = 5, ColorId = 5, DailyPrice = 200, Descriptions = "Otomatic Hybrid", ModelYear = 2010 });

        }

    }
}
