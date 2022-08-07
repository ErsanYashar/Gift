using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using myPosGift.Core.Services.Interfaces;
using X.PagedList;

namespace MyPosGift.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransaction transactionService;

        public TransactionController(ITransaction transactionService)
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
    }
}
