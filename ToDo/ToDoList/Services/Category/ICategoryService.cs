namespace ToDoList.Services.Category
{
    public interface ICategoryService
    {
        Task<List<Models.Category>> GetAllCategory();
    }
}
