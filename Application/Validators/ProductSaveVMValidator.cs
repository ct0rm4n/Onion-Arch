using FluentValidation;
using ViewModels.Product;

namespace Validators
{
    public class ProductSaveVMValidator :AbstractValidator<ProductSaveVM>
    {
        public ProductSaveVMValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required");

        }
    }
}