using Application.Dto;
using Application.Features.Todos.Commands.CreateTodoCommand;
using Application.Features.Todos.Commands.UpdateTodoCommand;
using Domain.Entities;

namespace Application.Interfaces;

public interface ITodoRepository
{
    Task<List<TodoItem>> GetAllTodosAsync(CancellationToken cancellationToken);

    Task<TodoItem> GetTodoItemByIdAsync(long id, CancellationToken cancellationToken);

    Task<bool> CreateTodoItemAsync(CreateTodoCommand createTodoCommand, CancellationToken cancellationToken);

    Task<bool> UpdateTodoItemAsync(UpdateTodoCommand updateCommand, CancellationToken cancellationToken);
}
