using FluentValidation;
using TPInvOp.Model.Entities;

namespace TPInvOp.Service.Validators
{
    public class LocalityValidator : AbstractValidator<Locality>
    {
        public LocalityValidator()
        {
            RuleFor(l => l.LocalityName)
                .NotEmpty().WithMessage("The {PropertyName} is required")
                .MinimumLength(3).WithMessage("Must have at least {MinLength} characters")
                .MaximumLength(100).WithMessage("No more than {MaxLength} characters");
        }
    }
}
