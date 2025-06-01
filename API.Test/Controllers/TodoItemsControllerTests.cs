using System.Threading;
using System.Threading.Tasks;
using TodoApi.Controllers;
using Application.Features.Todos.Commands.CreateTodoCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace API.Test.Controllers
{
    public class TodoItemsControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly TodoItemsController _controller;

        public TodoItemsControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new TodoItemsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateTodoItem_WithValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new CreateTodoCommand { Name = "Test Todo" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateTodoCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.CreateTodoItem(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<Dictionary<string, bool>>(okResult.Value);
            Assert.True(returnValue["status"]);
            _mediatorMock.Verify(m => m.Send(It.IsAny<CreateTodoCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task CreateTodoItem_WithNullCommand_ReturnsBadRequest()
        {
            // Arrange
            CreateTodoCommand command = null;

            // Act
            var result = await _controller.CreateTodoItem(command);

            // Assert
            Assert.IsType<BadRequestResult>(result.Result);
            _mediatorMock.Verify(m => m.Send(It.IsAny<CreateTodoCommand>(), It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
