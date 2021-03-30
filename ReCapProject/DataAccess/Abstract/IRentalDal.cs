using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRentalDal:IEntityRepository<Rental>
    {
        List<RentalDetailDto> GetRentalDetail(Expression<Func<RentalDetailDto, bool>> filter = null);
        Rental GetRentalDetailByCarId(Expression<Func<Rental, bool>> filter = null);
    }
}
