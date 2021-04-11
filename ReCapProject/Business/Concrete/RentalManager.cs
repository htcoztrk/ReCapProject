using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
        ICarService _carService;
        IFindeksService _findeksService;
        public RentalManager(IRentalDal rentalDal,ICarService carService,IFindeksService findeksService )
        {
            _rentalDal = rentalDal;
            _carService = carService;
            _findeksService = findeksService;
            
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {

            /* var result = _rentalDal.GetAll();  
             if (result.Where(r => r.CarId == rental.CarId
                     && r.ReturnDate >= rental.RentDate
                     && r.RentDate <= rental.ReturnDate).Any())
             {
                 return new ErrorResult(Messages.CarInRental);
             }
             else
             {
                 _rentalDal.Add(rental);
                 return new SuccessResult(Messages.Added);
             }*/

            var result = BusinessRules.Run(IsRentable(rental), CheckFindeksScore(rental));
            if (result != null)
            {
                return result;
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
        public IDataResult<List<RentalDetailDto>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetail(r=>r.CustomerId==customerId));
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
        public IResult CheckFindeksScore(Rental rental)
        {
            var  customer= _findeksService.GetByCustomerId(rental.CustomerId).Data;
            var car = _carService.GetById(rental.CarId).Data;
            if (customer == null)
            {
                return new ErrorResult(Messages.FindeksNotFound);
            }
            else
            {
                if (car.FindeksScore > customer.FindeksScore)
                {
                    return new ErrorResult(Messages.FindeksScoreNotEnough);
                }
                else
                {
                    return new SuccessResult(Messages.EnoughFindeksScore);
                }
            }
        }
            

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }
    }
}
