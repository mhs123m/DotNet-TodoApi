
using Application.Dto;
using Application.Features.Todos.Queries.GetTodoByIdQuery;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

public class GetTodoItemByIdHandler : IRequestHandler<GetTodoItemById, TodoDto>
{
    private readonly ITodoRepository _todoRepository;

    public GetTodoItemByIdHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }
    public async Task<TodoDto> Handle(GetTodoItemById request, CancellationToken cancellationToken)
    {
        var todoItem = await _todoRepository.GetTodoItemByIdAsync(request.Id ,cancellationToken);

        if (todoItem == null){
            return null;
        }
        var todoDto = new TodoDto(todoItem.Id, todoItem.Name, todoItem.IsComplete);

        return todoDto;
    }
}
