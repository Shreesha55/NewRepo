using Microsoft.AspNetCore.Mvc;
using TradeNetProject.Models;
using TradeNetProject.Services;

namespace TradeNetProject.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public IActionResult Index()
        {
            var transactions = _transactionService.GetAllTransactions();
            return View(transactions);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Transaction transaction)
        {
            transaction.Status = "Pending";
            _transactionService.AddTransaction(transaction);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var transaction = _transactionService.GetTransactionById(id);
            return View(transaction);
        }

        [HttpPost]
        public IActionResult Edit(Transaction transaction)
        {
            _transactionService.UpdateTransaction(transaction);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _transactionService.DeleteTransaction(id);
            return RedirectToAction("Index");
        }
    }
}