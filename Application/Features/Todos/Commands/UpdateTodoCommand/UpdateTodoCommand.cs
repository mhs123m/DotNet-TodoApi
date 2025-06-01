using MediatR;

namespace Application.Features.Todos.Commands.UpdateTodoCommand;

public class UpdateTodoCommand : IRequest<bool>
{
  public long Id { get; set; }
  public string? Name { get; set; }
  public bool IsCompleted { get; set; }
}

