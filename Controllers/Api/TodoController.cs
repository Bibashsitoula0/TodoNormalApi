using ApiTodo.Data;
using ApiTodo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiTodo.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TodoController : ControllerBase
    {
        private readonly TodoDbContext _context;

        public TodoController(TodoDbContext context)
        {
            _context = context;
        }

        public IActionResult GetTodos() => Ok(_context.Todo.ToList());

        [HttpGet("{id:int}")]
        public IActionResult GetTodo(int id)
        {
            if (id == null)
            {
                
                return BadRequest();
            }
            var todo = _context.Todo.Find(id);

            return Ok(todo);
        }

        [HttpPost]
        public IActionResult Create(Todo todo)
        {
            _context.Todo.Add (todo);
            _context.SaveChanges();
            return Ok(todo);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Todo todo)
        {
            try
            {
                var db = _context.Todo.Find(id);
                db.Name = todo.Name;
                db.Discription = todo.Discription;
                _context.SaveChanges();
                return Ok(todo);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var data = _context.Todo.Find(id);
            _context.Todo.Remove (data);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
