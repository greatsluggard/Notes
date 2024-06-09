using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Notes.Application.Mediators.Tag.Commands;
using Notes.Domain.DTO.Tag;
using Notes.Domain.Result;
using Tags.API.Controllers;

namespace Notes.Tests
{
    public class TagControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly TagController _tagController;

        public TagControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _tagController = new TagController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateTag_ReturnsOkResult_WhenResponseIsSuccess()
        {
            // Arrange
            var command = new CreateTagCommand(new CreateTagDTO("TestTag"));

            var response = new BaseResult<TagDTO>
            {
                ErrorMessage = null
            };

            _mediatorMock
                .Setup(m => m.Send(command, default))
                .ReturnsAsync(response);

            // Act
            var result = await _tagController.Create(command);

            // Assert
            result.Should().BeOfType<ActionResult<BaseResult<TagDTO>>>();

            var actionResult = result.Result as OkObjectResult;
            actionResult.Should().NotBeNull();
            actionResult.Value.Should().Be(response);
        }

        [Fact]
        public async Task UpdateTag_ReturnsOkResult_WhenResponseIsSuccess()
        {
            // Arrange
            var command = new UpdateTagCommand(new UpdateTagDTO(4, "TestTagName"));

            var response = new BaseResult<TagDTO>
            {
                ErrorMessage = null
            };

            _mediatorMock
                .Setup(m => m.Send(command, default))
                .ReturnsAsync(response);

            // Act
            var result = await _tagController.Update(command);

            // Assert
            result.Should().BeOfType<ActionResult<BaseResult<TagDTO>>>();

            var actionResult = result.Result as OkObjectResult;
            actionResult.Should().NotBeNull();
            actionResult.Value.Should().Be(response);
        }
    }
}