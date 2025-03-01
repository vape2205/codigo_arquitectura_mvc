using AutoMapper;
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
        private readonly IMapper _mapper;

        public TodoItemController(ITodoItemRepository repository,
            IMapper mapper)
        {
            _repository=repository;
            _mapper=mapper;
        }

        // GET: api/<TodoItemController>
        [HttpGet]
        public async Task<IEnumerable<ViewItem>> Get()
        {
            var list = await _repository.GetAllAsync();
            var listModel = new List<ViewItem>();
            return _mapper.Map<IEnumerable<ViewItem>>(list);
        }
    }
}
