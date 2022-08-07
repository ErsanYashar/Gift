using Microsoft.AspNetCore.Identity;
using myPosGift.Core.Services.Interfaces;
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
    }
}
