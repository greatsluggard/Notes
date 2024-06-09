using FluentValidation;
using Notes.Domain.DTO.Tag;

namespace Notes.Application.Validations.Tag
{
    public class UpdateTagValidator : AbstractValidator<UpdateTagDTO>
    {
        public UpdateTagValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        }
    }
}