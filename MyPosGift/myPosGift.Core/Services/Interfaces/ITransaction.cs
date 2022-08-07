using myPosGift.Core.ViewModel.Transaction;

namespace myPosGift.Core.Services.Interfaces
{
    public interface ITransaction 
    {
        IList<TransactionViewModel> GetAllTransaction();
    }
}
