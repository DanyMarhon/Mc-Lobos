using FluentValidation;
using TPInvOp.Web.ViewModels.Product;

namespace TPInvOp.Web.Validators
{
    public class ProductValidator : AbstractValidator<ProductEditVm>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName)
                .NotEmpty().WithMessage("The {PropertyName} is required")
                .MinimumLength(3).WithMessage("Must have at least {MinLength} characters")
                .MaximumLength(50).WithMessage("No more than {MaxLength} characters");
            RuleFor(p => p.Description).Length(0, 247).WithMessage("No more than 240 characters");
        }
    }
}
