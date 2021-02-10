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

            // TestToAdd(carManager,brandManager, colorManager);
            // TestToUpdate(carManager, brandManager, colorManager);
            //TestToDelete(carManager, brandManager, colorManager);
            Console.ReadKey();
        }
        
        static void TestToAdd(CarManager carManager , BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("************Testing to Add operation***********");
            brandManager.Add(new Brand { BrandId=8, BrandName = "Clio" });
            colorManager.Add(new Color {ColorId=8,  ColorName = "Red" });
            carManager.Add(new Car { BrandId = 5, CarId=5, ColorId = 5, DailyPrice = 200, Description = "Otomatic Dizel", ModelYear = 2010 });
         
        }
        static void TestToUpdate(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("************Testing to Update operation***********");
            brandManager.Update(new Brand { BrandId = 4, BrandName = "Mercedes" });
            colorManager.Update(new Color { ColorId = 5, ColorName = "Mavi" });
            carManager.Update(new Car { BrandId = 5, CarId = 5, ColorId = 5, DailyPrice = 200, Description = "Otomatic Hybrid", ModelYear = 2010 });
        }
        static void TestToDelete(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("************Testing to Delete operation***********");
            brandManager.Delete(new Brand { BrandId = 8, BrandName = "Clio" });
            colorManager.Delete(new Color { ColorId = 8, ColorName = "Red" });
            carManager.Delete(new Car { BrandId = 5, CarId = 5, ColorId = 5, DailyPrice = 200, Description = "Otomatic Hybrid", ModelYear = 2010 });

        }

    }
}
