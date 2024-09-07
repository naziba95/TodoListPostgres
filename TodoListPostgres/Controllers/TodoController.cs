using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoListPostgres.Dtos;
using TodoListPostgres.Repository;

namespace TodoListPostgres.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpPost]
        [Route("CreateTodo")]
        public async Task<IActionResult> CreateTodo(CreateDto createDto)
        {
            if (createDto == null)
            {
                var todo = await _todoRepository.CreateTodoItem(createDto);
                if(todo != null && todo.Title != "Error")
                {
                    return Ok(todo);
                }
                return BadRequest();
            }
            else return BadRequest();
        }
    }
}
