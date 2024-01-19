using BudgettingApplication.Enum;
using BudgettingApplication.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BudgettingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly Iservice _service;
        public IncomeController(Iservice service)
        {
            _service = service;
        }

        [HttpGet("GetAllIncome")]
        public async Task<ActionResult> GetAllIncomes()
        {
            var incomes = await _service.GetAllIncomes();
            return Ok(incomes);
        }

        [HttpGet("GetSpecificMonthIncomeById")]
        public async Task<IActionResult> GetMonthlyIncomeById(int userId, Months month)
        {
            var income = await _service.GetMonthlyIncome(userId, month);

            if (income == null)
            {
                return NotFound();
            }

            return Ok(income);
        }

        [HttpGet("GetIncomesByUserId/{userId}")]
        public async Task<IActionResult> GetIncomesByUserId(int userId)
        {
            var incomes = await _service.GetIncomesByUserId(userId);

            if (incomes == null || !incomes.Any())
            {
                return NotFound();
            }

            return Ok(incomes);
        }
        [HttpPost("AddNewIncome")]
        public async Task<ActionResult<Income>> AddIncome(Income income)
        {
            try
            {
                var addedIncome = await _service.AddIncome(income);
                return Ok(addedIncome);

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred while processing the request.");
            }

        }

        [HttpGet("GetMonthlyIncome/{userId}")]
        public async Task<IActionResult> GetMonthlyIncome(int userId)
        {
            var monthlyIncome = await _service.GetMonthlyIncome(userId);
            return Ok(monthlyIncome);
        }

        [HttpGet("GetQuarterlyIncome/{userId}")]
        public async Task<IActionResult> GetQuarterlyIncome(int userId)
        {
            var quarterlyIncome = await _service.GetQuarterlyIncome(userId);
            return Ok(quarterlyIncome);
        }

        [HttpGet("GetHalfYearlyIncome/{userId}")]
        public async Task<IActionResult> GetHalfYearlyIncome(int userId)
        {
            var halfYearlyIncome = await _service.GetHalfYearlyIncome(userId);
            return Ok(halfYearlyIncome);
        }

        [HttpGet("GetAnnualIncome/{userId}")]
        public async Task<IActionResult> GetAnnualIncome(int userId)
        {
            var annualIncome = await _service.GetAnnualIncome(userId);
            return Ok(annualIncome);
        }
    }
}
