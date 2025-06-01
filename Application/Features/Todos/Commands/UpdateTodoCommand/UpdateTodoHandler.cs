using Application.Interfaces;
using MediatR;

namespace Application.Features.Todos.Commands.UpdateTodoCommand;

public class UpdateTodoHandler : IRequestHandler<UpdateTodoCommand, bool>
{
  private readonly ITodoRepository todoRepository;

  public UpdateTodoHandler(ITodoRepository todoRepository)
  {
    this.todoRepository = todoRepository;
  }

  public async Task<bool> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
  {
    await todoRepository.UpdateTodoItemAsync(request, cancellationToken);

    return true;
  }
}
