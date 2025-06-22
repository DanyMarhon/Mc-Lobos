using FluentValidation;
using TPInvOp.Web.ViewModels.Locality;

namespace TPInvOp.Web.Validators
{
    public class LocalityValidator : AbstractValidator<LocalityEditVm>
    {
        public LocalityValidator()
        {
            RuleFor(c => c.LocalityName).NotEmpty().WithMessage("Required")
                .MinimumLength(3).WithMessage("Must have at least {MinLength} characters")
                .MaximumLength(50).WithMessage("No more than {MaxLength} characters");
        }
    }
}
