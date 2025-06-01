using Application.Features.Todos.Commands.CreateTodoCommand;
using Application.Features.Todos.Commands.UpdateTodoCommand;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly TodoContext _context;

    public TodoRepository(TodoContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateTodoItemAsync(CreateTodoCommand createTodoCommand, CancellationToken cancellationToken)
    {
        var entity = new TodoItem()
        {
            Name = createTodoCommand.Name,
        };
        _context.Add(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result > 0;
    }

    public async Task<List<TodoItem>> GetAllTodosAsync(CancellationToken cancellationToken)
    {
        return await _context.TodoItems.ToListAsync(cancellationToken);
    }

    public async Task<TodoItem> GetTodoItemByIdAsync(long id, CancellationToken cancellationToken)
    {
        return await _context.TodoItems.FindAsync(id,cancellationToken);
    }

    public async Task<bool> UpdateTodoItemAsync(UpdateTodoCommand updateCommand, CancellationToken cancellationToken)
    {
        var entity = await _context.TodoItems.FindAsync(updateCommand.Id, cancellationToken);
        if (entity == null)
        {
            return false;
        }
        entity.Name = updateCommand.Name;
        entity.IsComplete = updateCommand.IsCompleted;
        var result = await _context.SaveChangesAsync(cancellationToken);
        return result > 0;
    }
}
