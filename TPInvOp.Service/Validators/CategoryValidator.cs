using FluentValidation;
using TPInvOp.Model.Entities;

namespace TPInvOp.Service.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty().WithMessage("The {PropertyName} is required")
                .MaximumLength(50).WithMessage("The PropertyName must have no more than {ComparisonValue} characters");

            RuleFor(c => c.Description).NotEmpty()
                .MaximumLength(80).WithMessage("The PropertyDescription must have no more than {ComparisonValue} characters");
        }
    }
}
