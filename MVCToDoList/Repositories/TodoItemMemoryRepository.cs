using MVCToDoList.Interfaces;
using MVCToDoList.Models;

namespace MVCToDoList.Repositories
{
    public class TodoItemMemoryRepository : ITodoItemRepository
    {
        private static List<ToDoItem> _list = new List<ToDoItem>
        {
            new ToDoItem{ Description = "Item 1", Done = false },
            new ToDoItem{ Description = "Item 2", Done = false },
            new ToDoItem{ Description = "Item 3", Done = false },
            new ToDoItem{ Description = "Item 4", Done = false },
            new ToDoItem{ Description = "Item 5", Done = false },
            new ToDoItem{ Description = "Item 6", Done = false },
            new ToDoItem{ Description = "Item 7", Done = false },
            new ToDoItem{ Description = "Item 8", Done = false },
        };

        public Task Add(ToDoItem toDo)
        {
            _list.Add(toDo);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<ToDoItem>> GetAllAsync()
        {
            return Task.FromResult(_list.AsEnumerable());
        }

        public Task<ToDoItem> FindById(Guid guid)
        {
            var item = _list.FirstOrDefault(item => item.GuidItem == guid);
            return Task.FromResult(item);
        }

        public Task Remove(ToDoItem toDo)
        {
            _list.Remove(toDo);
            return Task.CompletedTask;
        }
    }
}
