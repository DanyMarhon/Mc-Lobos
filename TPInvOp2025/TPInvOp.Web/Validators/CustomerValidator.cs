using FluentValidation;
using TPInvOp.Web.ViewModels.Customer;

namespace TPInvOp.Web.Validators
{
    public class CustomerValidator : AbstractValidator<CustomerEditVm>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.CustomerName).NotEmpty().WithMessage("Required")
                .MinimumLength(3).WithMessage("Must have al least {MinLength} characters")
                .MaximumLength(100).WithMessage("No more than {MaxLength} characters");
            RuleFor(c => c.ContactPhone).NotEmpty().WithMessage("Required")
                .MaximumLength(15).WithMessage("Must be at most 15 characters")
                .Matches(@"^\+?[0-9]{7,15}$").WithMessage("Only numbers allowed, optionally starting with '+'");
            RuleFor(c => c.DeliveryAddress).NotEmpty().WithMessage("Required")
                .MinimumLength(3).WithMessage("Must have al least {MinLength} characters")
                .MaximumLength(247).WithMessage("No more than 240 characters");
        }
    }
}
