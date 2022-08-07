using Microsoft.AspNetCore.Identity;
using myPosGift.Core.Services.Interfaces;
using myPosGift.Core.ViewModel.Transaction;
using myPosGift.Infrastructure.Data;
using myPosGift.Infrastructure.Data.DateModels;

namespace myPosGift.Core.Services
{
    public class TransactionService : BaseService, ITransaction
    {
        public TransactionService(UserManager<User> userManager, ApplicationDbContext context)
            : base(userManager, context)
        {
        }

        public IList<TransactionViewModel> GetAllTransaction()
        {
            var transaction = this.Context.Transactions
                 .Select(x => new TransactionViewModel
                 {
                     Amount = x.Amount,
                     SenderName = x.SenderName,
                     RecipientName = x.RecipientName,
                     Date = x.Date,
                     Description= x.Description
                 })
                 .ToList();

            return transaction;
        }
    }
}
