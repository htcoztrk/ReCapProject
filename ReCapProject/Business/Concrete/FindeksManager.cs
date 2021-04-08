using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FindeksManager : IFindeksService
    {
        IFindeksDal _findeksDal;
        public FindeksManager(IFindeksDal findeksDal)
        {
            _findeksDal = findeksDal;
        }
        public IResult Add(Findeks findeks)
        {
            var newFindeks = CalculateFindeksScore(findeks).Data;
            _findeksDal.Add(newFindeks);
            return new SuccessResult(Messages.Added);
        }

        public IDataResult<Findeks> CalculateFindeksScore(Findeks findeks)
        {
            findeks.FindeksScore = new Random().Next(0, 1901);
            return new SuccessDataResult<Findeks>(findeks);
        }

        public IResult Delete(Findeks findeks)
        {
            _findeksDal.Delete(findeks);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Findeks>> GetAll()
        {
            return new SuccessDataResult<List<Findeks>>(_findeksDal.GetAll());
        }

        public IDataResult<Findeks> GetByCustomerId(int customerId)
        {
            var findeks= _findeksDal.Get(f => f.CustomerId == customerId);
            if (findeks == null) { return new ErrorDataResult<Findeks>(Messages.FindeksNotFound); }
            else { return new SuccessDataResult<Findeks>(findeks); }
        }

        public IDataResult<Findeks> GetById(int findeksId)
        {
            return new SuccessDataResult<Findeks>(_findeksDal.Get(f => f.FindeksId == findeksId));
        }

        public IResult Update(Findeks findeks)
        {
           //// var newFindeks = CalculateFindeksScore(findeks).Data;
            _findeksDal.Update(findeks);
            return new SuccessResult(Messages.Updated);
        }
    }
}
