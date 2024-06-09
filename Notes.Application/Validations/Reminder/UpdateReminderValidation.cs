using FluentValidation;
using Notes.Domain.DTO.Reminder;

namespace Notes.Application.Validations.Reminder
{
    public class UpdateReminderValidator : AbstractValidator<UpdateReminderDTO>
    {
        public UpdateReminderValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(250);
            RuleFor(x => x.Text).NotEmpty().MaximumLength(2000);
        }
    }
}