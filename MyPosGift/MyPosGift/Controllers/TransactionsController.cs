using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using myPosGift.Core.Services.Interfaces;
using myPosGift.Core.ViewModel.Transaction;
using myPosGift.Infrastructure.Data.DateModels;
using System.Security.Claims;
using X.PagedList;

namespace MyPosGift.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ITransaction transactionService;

        public TransactionsController(ITransaction transactionService, UserManager<User> userManager = null)
        {
            this.transactionService = transactionService;
        }


        [Authorize(Roles = "Admin")]
        public IActionResult All(int? page)
        {
            var transaction = this.transactionService.GetAllTransaction();

            var pageNumber = page ?? 1;
            var transactionPage = transaction.ToPagedList(pageNumber, 10);

            return this.View(transactionPage);
        }

        [Authorize]
        public IActionResult Dashboard(int? page)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var transaction = this.transactionService.AllTransacationsUser(userId);

            var pageNumber = page ?? 1;
            var transactionPage = transaction.ToPagedList(pageNumber, 10);

            return this.View(transactionPage);
        }


        [Authorize]
        public IActionResult SentGift(TransactionGiftModel item)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var sent = this.transactionService.Send(item, userId);

            return this.View();
        }




    }
}
