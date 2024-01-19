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
        public async Task<IActionResult> GetAllTransactions()
        {
            var transaction = await _service.GetAllTransactions();
            return Ok(transaction);
        }

        [HttpGet("GetTransactionsById/{id}")]
        public async Task<IActionResult> GetTransactionsById(int id)
        {
            var transaction = await _service.GetTransactionById(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
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
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            //catch (Exception ex)
            //{
            //    // Handle other exceptions
            //    return StatusCode(500, "Internal server error");
            //}
        }

    }
}
