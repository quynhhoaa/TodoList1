namespace ToDoList.Services.PasswordHash
{
    public class BCryptPassworkHash
    {
        public string HashPasswork(string password)
        {

            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public bool VerifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
