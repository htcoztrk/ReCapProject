using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, EfContextDal>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (EfContextDal context=new EfContextDal())
            {
                var result=from brand in context.Brands
                           join car in context.Cars
                           on brand.BrandId equals car.BrandId
                           join col in context.Colors
                           on car.ColorId equals col.ColorId
                           select new CarDetailDto
                           {
                               CarName=car.CarName, BrandName=brand.BrandName, ColorName=col.ColorName, DailyPrice=car.DailyPrice
                           };

                return result.ToList();        
            }
        }
    }
}
