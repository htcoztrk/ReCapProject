using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemory : ICarDal
    {
        List<Car> _cars;
        public InMemory(){
            _cars = new List<Car>
            {
                new Car{ BrandId=1, CarId=1, ColorId=1, DailyPrice=30, Descriptions="Car1", ModelYear=1990},
                new Car{ BrandId=2, CarId=2, ColorId=2, DailyPrice=40, Descriptions="Car2", ModelYear=1995},
                new Car{ BrandId=3, CarId=3, ColorId=3, DailyPrice=50, Descriptions="Car3", ModelYear=2000},
                new Car{ BrandId=4, CarId=4, ColorId=4, DailyPrice=60, Descriptions="Car4", ModelYear=2010},
                new Car{ BrandId=5, CarId=5, ColorId=5, DailyPrice=70, Descriptions="Car5", ModelYear=2020}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
            
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.CarId == Id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.Find(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Descriptions = car.Descriptions;
            carToUpdate.ModelYear = car.ModelYear;
            
        }
    }
}
