using Application.Dto;
using MediatR;

namespace Application.Features.Todos.Queries.GetAllTodosQuery;

public record GetAllTodosQuery() : IRequest<List<TodoDto>>;
