using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{

    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public  BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            //ubusiness codes
            //validation
            //nesnenin yapısal olarak dogru olup olmadıgını kontrol eder (validation)
         

                _brandDal.Add(brand);
                return new SuccessResult(Messages.Added);
           
        }
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.Deleted);
        }

        [ValidationAspect (typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            if (brand.BrandName.Length > 2)
            {
                _brandDal.Update(brand);
                return new SuccessResult(Messages.Updated);
            }
            else
            {
                return new ErrorResult(Messages.NameInvalid);
            }
        }
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.Listed);
        }
        public IDataResult<Brand> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b=>b.BrandId==id));
        }

        
    }
}
