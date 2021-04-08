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
    public class FakeCardManager:IFakeCardService
    {

        private IFakeCardDal _fakeCardDal;

        public FakeCardManager(IFakeCardDal fakeCardDal)
        {
            _fakeCardDal = fakeCardDal;
        }

        public IDataResult<List<FakeCard>> GetByCardNumber(string cardNumber)
        {
            return new SuccessDataResult<List<FakeCard>>(_fakeCardDal.GetAll(c => c.CardNumber == cardNumber));
        }

        public IDataResult<List<FakeCard>> GetAll()
        {
            return new SuccessDataResult<List<FakeCard>>(_fakeCardDal.GetAll());
        }

        public IDataResult<FakeCard> GetById(int cardId)
        {
            return new SuccessDataResult<FakeCard>(_fakeCardDal.Get(c => c.CardId == cardId));
        }

        public IResult IsCardExist(FakeCard fakeCard)
        {
            var result = _fakeCardDal.Get(c => c.NameOnTheCard == fakeCard.NameOnTheCard && c.CardNumber == fakeCard.CardNumber && c.CardCvv == fakeCard.CardCvv);
            if (result == null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IResult Add(FakeCard fakeCard)
        {
            _fakeCardDal.Add(fakeCard);
            return new SuccessResult();
        }

        public IResult Delete(FakeCard fakeCard)
        {
            _fakeCardDal.Delete(fakeCard);
            return new SuccessResult();
        }

        public IResult Update(FakeCard fakeCard)
        {
            _fakeCardDal.Update(fakeCard);
            return new SuccessResult();
        }

        public IDataResult<FakeCard> GetByCustomerId(int customerId)
        {

            var fakeCard=_fakeCardDal.Get(f => f.CustomerId == customerId);
            if (fakeCard == null) { return new ErrorDataResult<FakeCard>(Messages.CardNotFound); }
            else
            {
                return new SuccessDataResult<FakeCard>(fakeCard);
            }
           

        }
    }
}

