using FluentValidation;
using TPInvOp.Model.Entities;

namespace TPInvOp.Web.Validators
{
    public class PaymentMethodValidator : AbstractValidator<PaymentMethod>
    {
        public PaymentMethodValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("The {PropertyName} is required")
                .MinimumLength(3).WithMessage("Must have at least {MinLength} characters")
                .MaximumLength(50).WithMessage("No more than {MaxLength} characters");

        }


    }
}
