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
            try
            {
                var incomes = await _service.GetAllIncomes();
                return Ok(incomes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching all incomes: {ex.Message}");
            }
        }

        [HttpGet("GetSpecificMonthIncomeById")]
        public async Task<ActionResult> GetMonthlyIncomeById(int userId, Months month)
        {
            try
            {
                var income = await _service.GetMonthlyIncome(userId, month);
                if (income == null)
                {
                    return NotFound();
                }
                return Ok(income);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching the monthly income: {ex.Message}");
            }
        }

        [HttpGet("GetIncomesByUserId/{userId}")]
        public async Task<ActionResult> GetIncomesByUserId(int userId)
        {
            try
            {
                var incomes = await _service.GetIncomesByUserId(userId);
                if (incomes == null)
                {
                    return NotFound();
                }
                return Ok(incomes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching incomes by user ID: {ex.Message}");
            }
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
        public async Task<ActionResult> GetMonthlyIncome(int userId)
        {
            try
            {
                var monthlyIncome = await _service.GetMonthlyIncome(userId);
                return Ok(monthlyIncome);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching monthly income: {ex.Message}");
            }
        }

        [HttpGet("GetQuarterlyIncome/{userId}")]
        public async Task<ActionResult> GetQuarterlyIncome(int userId)
        {
            try
            {
                var quarterlyIncome = await _service.GetQuarterlyIncome(userId);
                return Ok(quarterlyIncome);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching quarterly income: {ex.Message}");
            }
        }

        [HttpGet("GetHalfYearlyIncome/{userId}")]
        public async Task<ActionResult> GetHalfYearlyIncome(int userId)
        {
            try
            {
                var halfYearlyIncome = await _service.GetHalfYearlyIncome(userId);
                return Ok(halfYearlyIncome);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching half-yearly income: {ex.Message}");
            }
        }

        [HttpGet("GetAnnualIncome/{userId}")]
        public async Task<ActionResult> GetAnnualIncome(int userId)
        {
            try
            {
                var annualIncome = await _service.GetAnnualIncome(userId);
                return Ok(annualIncome);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching annual income: {ex.Message}");
            }
        }
    }
}
