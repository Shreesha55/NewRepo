using Microsoft.AspNetCore.Mvc;
using TradeNetProject.Models;
using TradeNetProject.Services;

namespace TradeNetProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionApiController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionApiController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        /// <summary>
        /// Get all transactions
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            var transactions = _transactionService.GetAllTransactions();
            return Ok(transactions);
        }

        /// <summary>
        /// Get transaction by ID
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var transaction = _transactionService.GetTransactionById(id);
            if (transaction == null)
                return NotFound(new { message = "Transaction not found" });
            return Ok(transaction);
        }

        /// <summary>
        /// Create a new transaction
        /// </summary>
        [HttpPost]
        public IActionResult Create(Transaction transaction)
        {
            _transactionService.AddTransaction(transaction);
            return CreatedAtAction(nameof(GetById), new { id = transaction.TransactionID }, transaction);
        }

        /// <summary>
        /// Update an existing transaction
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, Transaction transaction)
        {
            var existing = _transactionService.GetTransactionById(id);
            if (existing == null)
                return NotFound(new { message = "Transaction not found" });

            transaction.TransactionID = id;
            _transactionService.UpdateTransaction(transaction);
            return Ok(new { message = "Transaction updated successfully" });
        }

        /// <summary>
        /// Delete a transaction
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var transaction = _transactionService.GetTransactionById(id);
            if (transaction == null)
                return NotFound(new { message = "Transaction not found" });
            
            _transactionService.DeleteTransaction(id);
            return Ok(new { message = "Transaction deleted successfully" });
        }
    }
}
