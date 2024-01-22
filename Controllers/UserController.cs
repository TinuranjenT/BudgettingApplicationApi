using BudgettingApplication.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BudgettingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Iservice _service;
        public UserController(Iservice service)
        {
            _service = service;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult> GetAllusers()
        {
            try
            {
                var users = await _service.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred while processing the request.");
            }
        }

        [HttpPost("AddNewUser")]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            try
            {
                var addedUser = await _service.AddUser(user);
                return Ok(addedUser);

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred while processing the request.");
            }
        }
    }
}
