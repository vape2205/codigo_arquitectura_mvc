using MVCToDoList.Models;

namespace MVCToDoList.Interfaces
{
    public interface ITodoItemRepository
    {
        Task<IEnumerable<ToDoItem>> GetAllAsync();
        Task<ToDoItem> FindById(Guid guid);
        Task Add(ToDoItem toDo);
        Task Remove(ToDoItem toDo);
        Task Update(ToDoItem toDo);
    }
}
