using FluentValidation;
using ViewModels.Category;

namespace Validators
{
    public  class CategorySaveVMValidator : AbstractValidator<CategorySaveVM>
    {
        public CategorySaveVMValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotNull()
                .WithMessage("{PropertyName} is required")
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
        }
    }
}
