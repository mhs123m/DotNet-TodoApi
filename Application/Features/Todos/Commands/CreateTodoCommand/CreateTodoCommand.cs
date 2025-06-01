using Application.Dto;
using Domain.Entities;
using MediatR;

namespace Application.Features.Todos.Commands.CreateTodoCommand;
public class CreateTodoCommand : IRequest<bool>
{
    public long? Id { get; set; }
    public string? Name { get; set; }
    public bool IsCompleted { get; set; }
}
