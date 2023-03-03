using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.DTOs;
using ToDoList.Models;
using ToDoList.Services.PasswordHash;
using ToDoList.Services.TokenGenerator;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly BCryptPassworkHash _bCryptPassworkHash;
        public static User user = new User();
        public readonly TodoDbContext _toDoDbContext;
        public readonly AccessTokenGenerator _tokenGenerator;
        public LogsController(BCryptPassworkHash bCryptPassworkHash, TodoDbContext toDoDbContext, AccessTokenGenerator tokenGenerator)
        {
            _bCryptPassworkHash = bCryptPassworkHash;
            _toDoDbContext = toDoDbContext;
            _tokenGenerator = tokenGenerator;
        }
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromBody] UserRequest userRequest)
        {
            var passwordHash = _bCryptPassworkHash.HashPasswork(userRequest.Password);
            user.Username = userRequest.Username;
            user.PasswordHash = passwordHash;
            user.Tasks = userRequest.Tasks;
            _toDoDbContext.Add(user);
            await _toDoDbContext.SaveChangesAsync();
            return Ok(user);
        }
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] UserRequest userRequest)
        {
            var userName = _toDoDbContext.Users.Where(x => x.Username == userRequest.Username);
            if(userName == null)
            {
                return BadRequest("User not found");

            }
            var passwordHash = _bCryptPassworkHash.HashPasswork(userRequest.Password);
            var password = _toDoDbContext.Users.Where(x => x.PasswordHash == passwordHash);
            if(password == null)
            {
                return BadRequest("Password not found");
            }
            var user = _toDoDbContext.Users.FirstOrDefault(x => x.Username == userRequest.Username && x.PasswordHash == passwordHash);
            if(!_bCryptPassworkHash.VerifyPassword(user.PasswordHash,userRequest.Password))
            {
                return BadRequest("Wrong password");
            }
            string token = _tokenGenerator.CreateToken(user);
            return Ok(token);
        }
    }
}
