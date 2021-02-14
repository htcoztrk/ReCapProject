using System;
using Business.Concrete;
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
            // TestToAdd(carManager,brandManager, colorManager);
            //TestToUpdate(carManager, brandManager, colorManager);
            //TestToDelete(carManager, brandManager, colorManager);

            //List of tables
            //ListOfCar(carManager);
            //ListOfColor(colorManager);
            //ListOfBrand(brandManager);

            //GetCarDetail(carManager);

            //Console.WriteLine("*********Car with Colorid= 3********************");
            //foreach (var c in carManager.GetCarsByColorId(3))
            //{
            //    Console.WriteLine("Car with Colorid=3"+c.CarId+" "+c.Description);
            //}
            //TestToAddUser(userManager);
            //TestToAddCustomer(customerManager);
            TestToUpdateCustomer(customerManager);
            Console.ReadKey();
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
        static void TestToAddUser(UserManager userManager)
        {
            Console.WriteLine("************Testing to Add User***********");
            userManager.Add(new User { FirstName="H", LastName="O", Email="ho@gmail.com" , Password="h1o1" });
            userManager.Add(new User { FirstName = "M", LastName = "O", Email = "mo@gmail.com", Password = "m1o1" });
        }
        static void TestToAddCustomer(CustomerManager customerManager)
        {
            Console.WriteLine("************Testing to Add Customer***********");

            var result = customerManager.Add(new Customer { UserId=2, CompanyName="Company 2" });
            Console.WriteLine(result.Message);
            

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
