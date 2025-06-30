using FluentValidation;
using TPInvOp.Web.ViewModels.Category;

namespace TPInvOp.Web.Validators
{
    public class CategoryValidator : AbstractValidator<CategoryEditVm>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty().WithMessage("Required")
                .MinimumLength(3).WithMessage("Must have al least {MinLength} characters")
                .MaximumLength(50).WithMessage("No more than {MaxLength} characters");
            RuleFor(c => c.Description).Length(0, 250).WithMessage("No more than 250 characters");
        }
    }
}
