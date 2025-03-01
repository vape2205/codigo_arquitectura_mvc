using Microsoft.AspNetCore.Mvc;
using MVCToDoList.DTOs.ToDoItem;
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
        public async Task<IEnumerable<ViewItem>> Get()
        {
            var list = await _repository.GetAllAsync();
            var listModel = new List<ViewItem>();
            foreach (var item in list)
            {
                listModel.Add(new ViewItem
                {
                    GuidItem = item.GuidItem,
                    Description = item.Description,
                    Done = item.Done
                });
            }
            return listModel;
        }
    }
}
