using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Notes.API.Controllers;
using Notes.Application.Mediators.Note.Commands;
using Notes.Domain.DTO.Note;
using Notes.Domain.Result;

namespace Notes.Tests
{
    public class NoteControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly NoteController _noteController;

        public NoteControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _noteController = new NoteController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateNote_ReturnsOkResult_WhenResponseIsSuccess()
        {
            // Arrange
            var command = new CreateNoteCommand(new CreateNoteDTO("TestNote", "This is a test note"));

            var response = new BaseResult<NoteDTO>
            {
                ErrorMessage = null
            };

            _mediatorMock
                .Setup(m => m.Send(command, default))
                .ReturnsAsync(response);

            // Act
            var result = await _noteController.Create(command);

            // Assert
            result.Should().BeOfType<ActionResult<BaseResult<NoteDTO>>>();

            var actionResult = result.Result as OkObjectResult;
            actionResult.Should().NotBeNull();
            actionResult.Value.Should().Be(response);
        }

        [Fact]
        public async Task UpdateNote_ReturnsOkResult_WhenResponseIsSuccess()
        {
            // Arrange
            var command = new UpdateNoteCommand(new UpdateNoteDTO(4, "TestNote", "This is a test note"));

            var response = new BaseResult<NoteDTO>
            {
                ErrorMessage = null
            };

            _mediatorMock
                .Setup(m => m.Send(command, default))
                .ReturnsAsync(response);

            // Act
            var result = await _noteController.Update(command);

            // Assert
            result.Should().BeOfType<ActionResult<BaseResult<NoteDTO>>>();

            var actionResult = result.Result as OkObjectResult;
            actionResult.Should().NotBeNull();
            actionResult.Value.Should().Be(response);
        }
    }
}