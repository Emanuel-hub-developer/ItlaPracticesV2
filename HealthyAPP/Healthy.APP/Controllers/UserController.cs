using HealthyAPP.ApplicationLayer.Contract;
using HealthyAPP.ApplicationLayer.DTOs.User;
using Microsoft.AspNetCore.Mvc;

namespace Healthy.APP.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
          _userService = userService;
        }

        [HttpGet]
        [Route("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(new { success = true, data = users });
        }

        [HttpGet]
        [Route("getUserById/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            return Ok(new { success = true, data = user });
        }

        [HttpPost]
        [Route("createUser")]

        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO request)
        {
            var user = await _userService.CreateUser(request);
            return Ok(new { success = true, data = user });

        }

        [HttpPut]
        [Route("updateUser/{id}")]

        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDTO request)
        {
           await _userService.UpdateUser(request);

            return NoContent();

        }

        [HttpDelete]
        [Route("DeleteUser/{id}")]

        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);

            return NoContent();
        }
    }
}
