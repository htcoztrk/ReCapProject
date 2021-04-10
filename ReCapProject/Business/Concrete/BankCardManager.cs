using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BankCardManager : IBankCardService
    {
        IBankCardDal _bankCardDal;
        public BankCardManager(IBankCardDal bankCardDal)
        {
            _bankCardDal = bankCardDal;
        }

        public IDataResult<List<BankCard>> GetAll()
        {
            return new SuccessDataResult<List<BankCard>>(_bankCardDal.GetAll());
        }

        public IDataResult<BankCard> GetByCardNumber(string cardNumber)
        {
            return new SuccessDataResult<BankCard>(_bankCardDal.Get(b => b.CardNumber == cardNumber));
        }

        public IResult IsCardExist(BankCard bankCard)
        {
            var result = _bankCardDal.Get(c => c.NameOnTheCard == bankCard.NameOnTheCard && c.CardNumber == bankCard.CardNumber && c.CardCvv == bankCard.CardCvv);
            if (result == null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IResult Update(BankCard bankCard)
        {
            _bankCardDal.Update(bankCard);
            return new SuccessResult();
        }
    }
}
