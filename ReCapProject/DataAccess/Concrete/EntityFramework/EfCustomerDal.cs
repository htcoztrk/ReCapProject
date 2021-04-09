using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, EfContextDal>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<CustomerDetailDto, bool>> filter = null)
        {
            using (EfContextDal context=new EfContextDal())
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.UserId equals u.Id
                             select new CustomerDetailDto
                             {
                                 CustomerId=c.CustomerId,
                                 UserId=c.UserId,
                                 CompanyName=c.CompanyName,
                                 FirstName=u.FirstName,
                                 LastName=u.LastName,
                                 Email=u.Email
                             };
                return filter == null
                ? result.ToList()
                : result.Where(filter).ToList();
            }
        }
    }
}
