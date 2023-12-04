using FluentValidation;
using ViewModels.AppUser;

namespace Validators
{
    public class LoginVMValidator : AbstractValidator<AppUserLoginVM>
    {
        public LoginVMValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required");
                                 
            RuleFor(x => x.Password).NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required");

        }
    }
}
