using FluentValidation;
using Notes.Domain.DTO.Note;

namespace Notes.Application.Validations.Note
{
    public class UpdateNoteValidator : AbstractValidator<UpdateNoteDTO>
    {
        public UpdateNoteValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(250);
            RuleFor(x => x.Text).NotEmpty().MaximumLength(2000);
        }
    }
}