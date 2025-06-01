using Application.Interfaces;
using Application.Features.Todos.Queries.GetAllTodosQuery;
using Domain.Entities;
using MediatR;
using Application.Dto;

namespace Application.Features.Todos.Queries.GetAllTodosQuery;

public class GetAllTodosQueryHandler : IRequestHandler<GetAllTodosQuery, List<TodoDto>>
{
    private readonly ITodoRepository _todoRepository;

    public GetAllTodosQueryHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<List<TodoItem>> Handle(GetAllTodosQuery request, CancellationToken cancellationToken)
    {
        return await _todoRepository.GetAllTodosAsync(cancellationToken);
    }

    async Task<List<TodoDto>> IRequestHandler<GetAllTodosQuery, List<TodoDto>>.Handle(GetAllTodosQuery request, CancellationToken cancellationToken)
    {
        var todoItems = await _todoRepository.GetAllTodosAsync(cancellationToken);

        var todoDtos = todoItems.Select(todo => new TodoDto(todo.Id , todo.Name, todo.IsComplete)).ToList();

        return todoDtos;


    }
}
