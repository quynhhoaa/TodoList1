using ToDoList.DTOs;

namespace ToDoList.Services.ToDo
{
    public interface IToDoService
    {
        Task<List<Models.Todo>> GetTasks(Guid userId, FilterRequest filterRequest);
        Task<Models.Todo> GetById(Guid taskid);
        Task AddNewTask(ToDoRequest toDo);
        Task EditTask(Guid userId,Guid taskId,ToDoRequest toDo);
        Task DeleteTask(Guid userId,Guid taskId);
        Task CompleteTask(Guid userId,ToDoRequest toDo,List<Guid> taskIDs); 
    }
}
