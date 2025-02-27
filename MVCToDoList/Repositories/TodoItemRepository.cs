using Microsoft.EntityFrameworkCore;
using MVCToDoList.Interfaces;
using MVCToDoList.Models;
using MVCToDoList.Persistence;

namespace MVCToDoList.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly AppDbContext _appDbContext;

        public TodoItemRepository(AppDbContext appDbContext)
        {
            _appDbContext=appDbContext;
        }
        public async Task Add(ToDoItem toDo)
        {
            await _appDbContext.AddAsync(toDo);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Update(ToDoItem toDo)
        {
            _appDbContext.Update(toDo);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<ToDoItem> FindById(Guid guid)
        {
            var item = await _appDbContext.FindAsync<ToDoItem>(guid);
            return item;
        }

        public async Task<IEnumerable<ToDoItem>> GetAllAsync()
        {
            var lista =  await _appDbContext.TodoItems.ToListAsync();
            return lista;
        }

        public async Task Remove(ToDoItem toDo)
        {
            _appDbContext.Remove(toDo);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
