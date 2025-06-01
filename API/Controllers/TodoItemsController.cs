using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;
using Domain.Entities;
using MediatR;
using Application.Features.Todos.Queries.GetAllTodosQuery;
using Application.Features.Todos.Queries.GetTodoByIdQuery;
using Application.Features.Todos.Commands.CreateTodoCommand;
using Application.Dto;
using Application.Features.Todos.Commands.UpdateTodoCommand;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<TodoItem>> GetAllTodoItems()
        {
            var todos = await _mediator.Send(new GetAllTodosQuery());
            return Ok(todos);
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItemById(long id)
        {
            var todo = await _mediator.Send(new GetTodoItemById() {Id = id});
            if (todo == null){
                return NotFound();
            }
            return Ok(todo);
        }


        //         // PUT: api/TodoItems/5
        //         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("[action]")]
        public async Task<ActionResult<TodoItem>> PutTodoItem(long id, UpdateTodoCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }
            var todo = await _mediator.Send(command);
            var dict = new Dictionary<string, bool>
            {
                {"status", todo}
            };
            return Ok(dict);

        }

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoDto>> CreateTodoItem(CreateTodoCommand command)
        {
            if (command == null){
                return BadRequest();
            }

            var todo = await _mediator.Send(command);

            var dict = new Dictionary<string, bool>
            {
                { "status", todo }
            };

            return Ok(dict);



        }
//         // DELETE: api/TodoItems/5
//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteTodoItem(long id)
//         {
//             var todoItem = await _context.TodoItems.FindAsync(id);
//             if (todoItem == null)
//             {
//                 return NotFound();
//             }

//             _context.TodoItems.Remove(todoItem);
//             await _context.SaveChangesAsync();

//             return NoContent();
//         }

//         private bool TodoItemExists(long id)
//         {
//             return _context.TodoItems.Any(e => e.Id == id);
//         }
    }
}
