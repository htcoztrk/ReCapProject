using Core.DataAccess.EntityFramework;
using Core.Entities;
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
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (EfContextDal context=new EfContextDal())
            {
                var result=from brand in context.Brands
                           join car in context.Cars
                           on brand.BrandId equals car.BrandId
                           join col in context.Colors
                           on car.ColorId equals col.ColorId
                           //join image in context.CarImages
                           //on car.CarId equals image.CarId
                           select new CarDetailDto
                           {
                               CarName=car.CarName, CarId=car.CarId,
                               BrandName=brand.BrandName, ColorName=col.ColorName, 
                               DailyPrice=car.DailyPrice, Descriptions=car.Descriptions,
                               ModelYear=car.ModelYear,  BrandId=brand.BrandId, ColorId=col.ColorId,
                               FindeksScore=car.FindeksScore,
                               ImagePath = (from a in context.CarImages where a.CarId == car.CarId select a.ImagePath).FirstOrDefault()
                           };

                //return result.ToList();  
                return filter == null
                 ? result.ToList()
                 : result.Where(filter).ToList();

            }

        }

      

      
    }
}
