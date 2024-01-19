using BudgettingApplication.Enum;
using BudgettingApplication.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BudgettingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly Iservice _service;
        public ExpenseController(Iservice service)
        {
            _service = service;
        }
        [HttpGet("GetAllExpenses")]
        public async Task<ActionResult> GetAllExpenses()
        {
            var expenses = await _service.GetAllExpenses();
            return Ok(expenses);
        }

        [HttpGet("GetSpecificMonthExpenseById")]
        public async Task<IActionResult> GetMonthlyExpenseById(int userId, Months month)
        {
            var expense = await _service.GetMonthlyExpense(userId, month);

            if (expense == null)
            {
                return NotFound();
            }

            return Ok(expense);
        }

        [HttpGet("GetExpensesByUserId/{userId}")]
        public async Task<IActionResult> GetExpensesByUserId(int userId)
        {
            var incomes = await _service.GetExpensesByUserId(userId);

            if (incomes == null || !incomes.Any())
            {
                return NotFound();
            }

            return Ok(incomes);
        }
        [HttpPost("AddExpense")]
        public async Task<ActionResult<Expense>> AddExpense(Expense expense)
        {
            try
            {
                var addedExpense = await _service.AddExpense(expense);
                return Ok(addedExpense);

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred while processing the request.");
            }

        }

        [HttpGet("GetMonthlyExpense/{userId}")]
        public async Task<IActionResult> GetMonthlyExpense(int userId)
        {
            var monthlyExpense = await _service.GetMonthlyExpense(userId);
            return Ok(monthlyExpense);
        }

        [HttpGet("GetQuarterlyExpense/{userId}")]
        public async Task<IActionResult> GetQuarterlyExpense(int userId)
        {
            var quarterlyExpense = await _service.GetQuarterlyExpense(userId);
            return Ok(quarterlyExpense);
        }

        [HttpGet("GetHalfYearlyExpense/{userId}")]
        public async Task<IActionResult> GetHalfYearlyExpense(int userId)
        {
            var halfYearlyExpense = await _service.GetHalfYearlyExpense(userId);
            return Ok(halfYearlyExpense);
        }

        [HttpGet("GetAnnualExpense/{userId}")]
        public async Task<IActionResult> GetAnnualExpense(int userId)
        {
            var annualExpense = await _service.GetAnnualExpense(userId);
            return Ok(annualExpense);
        }
    
    }
}
