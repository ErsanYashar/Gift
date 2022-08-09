using myPosGift.Core.ViewModel.Transaction;
using System.Transactions;

namespace myPosGift.Core.Services.Interfaces
{
    public interface ITransaction 
    {
        IList<TransactionViewModel> GetAllTransaction();
        IList<TransactionViewModel> AllTransacationsUser(string Id);
        bool Send(TransactionGiftModel transaction, string Id);

    }
}
