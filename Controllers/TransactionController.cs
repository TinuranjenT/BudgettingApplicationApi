using BudgettingApplication.Enum;
using BudgettingApplication.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BudgettingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly Iservice _service;
        public TransactionController(Iservice service)
        {
            _service = service;
        }

        [HttpGet("GetAllTransactions")]
        public async Task<ActionResult> GetAllTransactions()
        {
            try
            {
                var transactions = await _service.GetAllTransactions();
                return Ok(transactions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching all transactions: {ex.Message}");
            }
        }

        [HttpGet("GetTransactionsById/{id}")]
        public async Task<ActionResult> GetTransactionsById(int id)
        {
            try
            {
                var transaction = await _service.GetTransactionById(id);

                if (transaction == null)
                {
                    return NotFound();
                }
                return Ok(transaction);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching the transaction: {ex.Message}");
            }
        }

        [HttpPost("AddNewTransaction")]
        public async Task<ActionResult> AddTransaction(Transaction transaction)
        {
            try
            {
                if (transaction == null)
                {
                    return BadRequest("Invalid transaction data");
                }
                await _service.AddTransaction(transaction);
                return Ok("Transaction added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while processing the transaction.");
            }
        }

    }
}
