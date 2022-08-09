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

        public bool Send(TransactionGiftModel item, string Id)
        {
            var user = this.users.GetUserById(Id);

            var recipient = this.users.GetUserPhoneNumber(item.PhoneNumber);

            if (user.Credits < item.Amount || user.PhoneNumber == recipient.PhoneNumber || recipient == null)
            {
                return false;
            }

            recipient.Credits += item.Amount;

            user.Credits -= item.Amount;

            var transaction = new Transaction
            {
                Amount = item.Amount,
                Description = item.Description,
                RecipientName = recipient.FirstName,
                SenderName = user.FirstName,
                Date = DateTime.UtcNow.ToLocalTime(),
            };

            this.Context.Add(transaction);

            this.Context.SaveChanges();

            return true;
        }
    }
}
