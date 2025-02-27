using Microsoft.AspNetCore.Mvc;
using MVCToDoList.Interfaces;
using MVCToDoList.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCToDoList.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly ITodoItemRepository _repository;

        public TodoItemController(ITodoItemRepository repository)
        {
            _repository=repository;
        }

        // GET: api/<TodoItemController>
        [HttpGet]
        public async Task<IEnumerable<ToDoItem>> Get()
        {
            return await _repository.GetAllAsync();
        }

        // DELETE api/<TodoItemController>/5
        [HttpDelete("{id}")]
        public async void Delete(Guid id)
        {
            var item = await _repository.FindById(id);
            await _repository.Remove(item);
        }
    }
}
