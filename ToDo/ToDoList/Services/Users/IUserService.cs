using ToDoList.Models;

namespace ToDoList.Services.Users
{
    public interface IUserService
    {
        Task <List<Models.User>> GetUsers();
        Task <Models.User> GetUserById(Guid userId);
        Task <Models.User> GetUserByName(string name);
        Task PutUser(Guid userId, User user);
        Task PostUser(User user);
        Task DeleteUser(Guid userId);
    }
}
