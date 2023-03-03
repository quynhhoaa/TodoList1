using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ToDoList.Models;

namespace ToDoList.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly TodoDbContext _todoDbContext;
        public CategoryService(TodoDbContext todoDbContext)
        {
            _todoDbContext = todoDbContext;
        }

        public async Task<List<Models.Category>> GetAllCategory()
        {
            return await _todoDbContext.Categories.ToListAsync();
        }
    }
}
