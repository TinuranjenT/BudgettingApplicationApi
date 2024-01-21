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
            try
            {
                var expenses = await _service.GetAllExpenses();
                return Ok(expenses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching all expenses: {ex.Message}");
            }
        }

        [HttpGet("GetSpecificMonthExpenseById")]
        public async Task<ActionResult> GetMonthlyExpenseById(int userId, Months month)
        {
            try
            {
                var expense = await _service.GetMonthlyExpense(userId, month);

                if (expense == null)
                {
                    return NotFound();
                }

                return Ok(expense);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching the monthly expense: {ex.Message}");
            }
        }

        [HttpGet("GetExpensesByUserId/{userId}")]
        public async Task<ActionResult> GetExpensesByUserId(int userId)
        {
            try
            {
                var incomes = await _service.GetExpensesByUserId(userId);
                if (incomes == null)
                {
                    return NotFound();
                }
                return Ok(incomes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching expenses by user ID: {ex.Message}");
            }
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
        public async Task<ActionResult> GetMonthlyExpense(int userId)
        {
            try
            {
                var monthlyExpense = await _service.GetMonthlyExpense(userId);
                return Ok(monthlyExpense);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching monthly expense: {ex.Message}");
            }
        }

        [HttpGet("GetQuarterlyExpense/{userId}")]
        public async Task<ActionResult> GetQuarterlyExpense(int userId)
        {
            try
            {
                var quarterlyExpense = await _service.GetQuarterlyExpense(userId);
                return Ok(quarterlyExpense);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching quarterly expense: {ex.Message}");
            }
        }

        [HttpGet("GetHalfYearlyExpense/{userId}")]
        public async Task<ActionResult> GetHalfYearlyExpense(int userId)
        {
            try
            {
                var halfYearlyExpense = await _service.GetHalfYearlyExpense(userId);
                return Ok(halfYearlyExpense);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching half-yearly expense: {ex.Message}");
            }
        }

        [HttpGet("GetAnnualExpense/{userId}")]
        public async Task<ActionResult> GetAnnualExpense(int userId)
        {
            try
            {
                var annualExpense = await _service.GetAnnualExpense(userId);
                return Ok(annualExpense);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching annual expense: {ex.Message}");
            }
        }
    }
}
