using Application.Dto.ViewModels.Banner;
using FluentValidation;

namespace Validators
{
    public  class BannerVMValidator : AbstractValidator<BannerVM>
    {
        public BannerVMValidator()
        {            
            RuleFor(x => x.Binary)
                .NotNull()
                .WithMessage("{PropertyName} is required")
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
        }
    }
}
