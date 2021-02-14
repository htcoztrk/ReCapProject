using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, EfContextDal>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetail()
        {
            using (EfContextDal context=new EfContextDal())
            {
                var result = from user in context.Users
                             join customer in context.Customers
                             on user.UserId equals customer.UserId
                             join rental in context.Rentals
                             on customer.CustomerId equals rental.CustomerId
                             join car in context.Cars
                             on rental.CarId equals car.CarId
                             select new RentalDetailDto
                             {
                                 UserId=user.UserId, CarId=car.CarId,
                                 CarName =car.CarName, CompanyName=customer.CompanyName,
                                 CustomerId =customer.CustomerId, FirstName=user.FirstName,
                                 LastName =user.LastName, RentalId=rental.RentalId,
                                 RentDate =rental.RentDate, ReturnDate=rental.ReturnDate
                             };
                return result.ToList();
            }

        }
    }
}
