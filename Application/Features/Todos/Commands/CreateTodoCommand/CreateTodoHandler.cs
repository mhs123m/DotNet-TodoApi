using Application.Dto;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Todos.Commands.CreateTodoCommand;
public class CreateTodoHandler : IRequestHandler<CreateTodoCommand, bool>
{
    private readonly ITodoRepository todoRepository;

    public CreateTodoHandler(ITodoRepository todoRepository)
    {
        this.todoRepository = todoRepository;
    }

    public async Task<bool> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        await todoRepository.CreateTodoItemAsync(request,cancellationToken);

        return true;
    }
}