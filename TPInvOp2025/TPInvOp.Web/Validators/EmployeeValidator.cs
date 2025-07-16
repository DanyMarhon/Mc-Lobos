using FluentValidation;
using TPInvOp.Web.ViewModels.Employee;

namespace TPInvOp.Web.Validators
{
    public class EmployeeValidator : AbstractValidator<EmployeeEditVm>
    {
        public EmployeeValidator()
        {
            RuleFor(e => e.EmployeeName).NotEmpty().WithMessage("Required")
                .MinimumLength(3).WithMessage("Must have al least {MinLength} characters")
                .MaximumLength(50).WithMessage("No more than {MaxLength} characters");
            RuleFor(e => e.Position).NotEmpty().WithMessage("Required")
                .MinimumLength(10).WithMessage("Must have al least 3 characters")
                .MaximumLength(47).WithMessage("No more than 40 characters");
        }
    }
}
