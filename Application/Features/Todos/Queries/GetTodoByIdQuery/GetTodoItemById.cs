using Application.Dto;
using MediatR;

namespace Application.Features.Todos.Queries.GetTodoByIdQuery;

public class GetTodoItemById : IRequest<TodoDto>
{
    public long Id { get; set; }
}



