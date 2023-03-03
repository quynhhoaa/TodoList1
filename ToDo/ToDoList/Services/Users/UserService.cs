using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Services.Users
{
    public class UserService : IUserService
    {
        private readonly TodoDbContext _todoDbContext;
        public UserService(TodoDbContext todoDbContext)
        {
            _todoDbContext = todoDbContext;
        }

        public async Task DeleteUser(Guid userId)
        {
            var item = _todoDbContext.Users.FirstOrDefault(x => x.Id == userId);
            if(item != null)
            {
                _todoDbContext.Users.Remove(item);
                await _todoDbContext.SaveChangesAsync();
            }
            await _todoDbContext.SaveChangesAsync();
        }

        public async Task<Models.User> GetUserById(Guid userId)
        {
            return await _todoDbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
        }

        public async Task<Models.User> GetUserByName(string name)
        {
            return await _todoDbContext.Users.FirstOrDefaultAsync(x => x.Username == name);
        }

        public async Task<List<Models.User>> GetUsers()
        {
            return await _todoDbContext.Users.ToListAsync();
        }

        public async Task PostUser(User user)
        {
            var userMD = new User
            {
                Username = user.Username,
                Email = user.Email,
                Tasks = user.Tasks,
                PasswordHash = user.PasswordHash
            };
            _todoDbContext.Users.Add(userMD);
            await _todoDbContext.SaveChangesAsync();
        }

        public async Task PutUser(Guid userId, User user)
        {
           var item = _todoDbContext.Users.FirstOrDefault(x => x.Id == userId);
            if(item != null )
            {
                item.Username = item.Username;
                item.Email = item.Email;
                item.Tasks = item.Tasks;
                item.PasswordHash = item.PasswordHash;
                _todoDbContext.Users.Update(item);
            }
            await _todoDbContext.SaveChangesAsync();

        }
    }
}
