using FluentValidation;
using TPInvOp.Model.Entities;

namespace TPInvOp.Service.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty().WithMessage("The {PropertyName} is required")
               .MinimumLength(3).WithMessage("Must have al least {MinLength} characters")
               .MaximumLength(50).WithMessage("No more than {MaxLength} characters");

            RuleFor(c => c.Description)
                .MaximumLength(255).WithMessage("No more than {MaxLength} characters");
        }
    }
}
