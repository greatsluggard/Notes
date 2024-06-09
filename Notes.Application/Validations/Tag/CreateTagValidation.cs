using FluentValidation;
using Notes.Domain.DTO.Tag;

namespace Notes.Application.Validations.Tag
{
    public class CreateTagValidator : AbstractValidator<CreateTagDTO>
    {
        public CreateTagValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        }
    }
}