using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDoList.Models;
using ToDoList.Services.Users;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<List<User>> GetUser()
        {
            return await _userService.GetUsers();
        }
        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetById(Guid id)
        {
            await _userService.GetUserById(id);
            return Ok();
        }
        [HttpGet]
        [Route("userName")]
        public async Task<IActionResult> GetByUserName(string userName)
        {
            await _userService.GetUserByName(userName);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            await _userService.PostUser(user);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutUser([FromBody] User user, Guid userId)
        {
            var id = Guid.Parse(HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).FirstOrDefault());
            await _userService.PutUser(id, user);
            return Ok(user);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromBody] Guid userId)
        {
            var id = Guid.Parse(HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).FirstOrDefault());
            await _userService.DeleteUser(id);
            return Ok();
        }
    }
}
