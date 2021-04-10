using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBankCardService
    {
        IDataResult<BankCard> GetByCardNumber(string cardNumber);
        IResult IsCardExist(BankCard bankCard);
        IResult Update(BankCard bankCard);
        IDataResult<List<BankCard>> GetAll();
    }
}
