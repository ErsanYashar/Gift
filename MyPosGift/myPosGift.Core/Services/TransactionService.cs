using Microsoft.AspNetCore.Identity;
using myPosGift.Core.Services.Interfaces;
using myPosGift.Core.ViewModel.Transaction;
using myPosGift.Infrastructure.Data;
using myPosGift.Infrastructure.Data.DateModels;

namespace myPosGift.Core.Services
{
    public class TransactionService : BaseService, ITransaction
    {
        private readonly IUsersService users;
        public TransactionService(UserManager<User> userManager, ApplicationDbContext context, IUsersService users)
            : base(userManager, context)
        {
            this.users = users;
        }

        public IList<TransactionViewModel> AllTransacationsUser(string Id)
        {
            var currentUserFirstName = this.users.GetUserById(Id).FirstName;

            var transactions = GetAllTransaction()
                .Where(t => t.SenderName == currentUserFirstName ||
                    t.RecipientName == currentUserFirstName)
                .ToList();
            return transactions;

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
