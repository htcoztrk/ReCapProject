using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var rentalList = _rentalDal.GetAll(x => x.CarId == rental.CarId && x.ReturnDate == null);
            if (rentalList.Count>0)
            {
                return new ErrorResult(Messages.CarInRental);

            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.Added);
            }
           
        }
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.Listed);
        }
        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == id));
        }
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetail());
        }

        public IDataResult<Rental> GetRentalDetailsByCarId(int carId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.GetRentalDetailByCarId(r => r.CarId == carId));
        }

        public IResult IsRentable(Rental rental)
        {
           
                var result = _rentalDal.GetAll();
                if (result.Where(r => r.CarId == rental.CarId
                        && r.ReturnDate >= rental.RentDate
                        && r.RentDate <= rental.ReturnDate).Any())
                    return new ErrorResult(Messages.RentalInValid);
                return new SuccessResult(Messages.CarIsRentable);
            
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }
    }
}
