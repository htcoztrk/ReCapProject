using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                if (car.CarName.Length>2)
                {
                    _carDal.Add(car);
                    Console.WriteLine("Car added successfully.");
                }
                else
                {
                    Console.WriteLine("Car Name must be longer than 2.");
                }
                
            }
            else
            {
                Console.WriteLine("Daily Price must be bigger than 0.");
            }
            
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine(car.CarId+" Car deleted successfully.");
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();  
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId== id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c => c.DailyPrice > min && c.DailyPrice < max);
        }

        public List<Car> GetByModelYear(int year)
        {
            return _carDal.GetAll(c => c.ModelYear == year);
        }

        public void Update(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Update(car);
                Console.WriteLine("Car info updated.");
            }
            else
            {
                Console.WriteLine("Daily Price must be bigger than 0.");
            }
            
        }
    }
}
