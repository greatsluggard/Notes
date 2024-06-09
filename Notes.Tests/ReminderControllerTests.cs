using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Notes.Domain.DTO.Reminder;
using Notes.Domain.Result;
using Reminders.API.Controllers;
using Reminders.Application.Mediators.Reminder.Commands;

namespace Notes.Tests
{
    public class ReminderControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly ReminderController _reminderController;

        public ReminderControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _reminderController = new ReminderController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateReminder_ReturnsOkResult_WhenResponseIsSuccess()
        {
            // Arrange
            var command = new CreateReminderCommand(new CreateReminderDTO("TestReminder", "This is a test reminder"));

            var response = new BaseResult<ReminderDTO>
            {
                ErrorMessage = null
            };

            _mediatorMock
                .Setup(m => m.Send(command, default))
                .ReturnsAsync(response);

            // Act
            var result = await _reminderController.Create(command);

            // Assert
            result.Should().BeOfType<ActionResult<BaseResult<ReminderDTO>>>();

            var actionResult = result.Result as OkObjectResult;
            actionResult.Should().NotBeNull();
            actionResult.Value.Should().Be(response);
        }

        [Fact]
        public async Task UpdateReminder_ReturnsOkResult_WhenResponseIsSuccess()
        {
            // Arrange
            var command = new UpdateReminderCommand(new UpdateReminderDTO(4, "TestReminder", "This is a test reminder"));

            var response = new BaseResult<ReminderDTO>
            {
                ErrorMessage = null
            };

            _mediatorMock
                .Setup(m => m.Send(command, default))
                .ReturnsAsync(response);

            // Act
            var result = await _reminderController.Update(command);

            // Assert
            result.Should().BeOfType<ActionResult<BaseResult<ReminderDTO>>>();

            var actionResult = result.Result as OkObjectResult;
            actionResult.Should().NotBeNull();
            actionResult.Value.Should().Be(response);
        }
    }
}